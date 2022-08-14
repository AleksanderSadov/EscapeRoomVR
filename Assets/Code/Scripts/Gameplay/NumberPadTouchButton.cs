using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace EscapeRoom.Gameplay
{
    public class NumberPadTouchButton : XRBaseInteractable
    {
        [Header("Visuals")]
        public Material normalMaterial;
        public Material touchedMaterial;
        public float touchedFromDistanceTime = 1f;

        [Header("Button Data")]
        public int buttonNumber;
        public NumberPad linkedNumberpad;

        private int numberOfInteractorTouching = 0;
        private Renderer rendererToChange;

        private void Start()
        {
            rendererToChange = GetComponent<MeshRenderer>();
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);

            if (args.interactorObject is XRRayInteractor)
            {
                return;
            }

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

            if (args.interactorObject is XRRayInteractor)
            {
                return;
            }

            numberOfInteractorTouching -= 1;

            if (numberOfInteractorTouching == 0)
            {
                rendererToChange.material = normalMaterial;
            }
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            StartCoroutine(PressButtonFromDistance());
        }

        private IEnumerator PressButtonFromDistance()
        {
            linkedNumberpad.ButtonPressed(buttonNumber);

            rendererToChange.material = touchedMaterial;
            yield return new WaitForSeconds(touchedFromDistanceTime);
            rendererToChange.material = normalMaterial;
        }
    }
}