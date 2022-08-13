using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace EscapeRoom.Gameplay
{
    public class NumberPadTouchButton : XRBaseInteractable
    {
        [Header("Visuals")]
        public Material normalMaterial;
        public Material touchedMaterial;

        [Header("Button Data")]
        public int buttonNumber;
        public NumberPad linkedNumberpad;

        private int numberOfInteractorTouching = 0;
        private Renderer rendererToChange;

        private void Start()
        {
            rendererToChange = GetComponent<MeshRenderer>();
        }

        public override bool IsHoverableBy(IXRHoverInteractor interactor)
        {
            return base.IsHoverableBy(interactor) && (interactor is XRDirectInteractor);
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);

            if (numberOfInteractorTouching == 0)
            {
                rendererToChange.material = touchedMaterial;
                linkedNumberpad.ButtonPressed(buttonNumber);
            }

            numberOfInteractorTouching += 1;
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);

            numberOfInteractorTouching -= 1;

            if (numberOfInteractorTouching == 0)
            {
                rendererToChange.material = normalMaterial;
            }
        }
    }
}