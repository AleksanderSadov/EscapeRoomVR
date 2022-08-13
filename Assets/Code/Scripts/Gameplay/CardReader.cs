using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace EscapeRoom.Gameplay
{
    public class CardReader : XRSocketInteractor
    {
        [Header("CardReader ReaderOptions Data")]
        public float allowedUprightErrorRange = 0.2f;
        public float requiredSwipeDistance = 0.15f;

        [Header("Success References")]
        public GameObject visualLockToHide;
        public DoorHandle handleToEnable;

        private Vector3 hoverEntry;
        private bool swipeIsValid;

        private Transform keycardTransform;

        protected override void Start()
        {
            base.Start();

            handleToEnable.enabled = false;
        }

        public override bool CanSelect(IXRSelectInteractable interactable)
        {
            return false;
        }

        public override bool CanHover(IXRHoverInteractable interactable)
        {
            return interactable is Keycard;
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);

            keycardTransform = args.interactableObject.transform;
            hoverEntry = keycardTransform.position;
            swipeIsValid = true;
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);

            Vector3 entryToExit = keycardTransform.position - hoverEntry;

            if (swipeIsValid && entryToExit.y < -requiredSwipeDistance)
            {
                visualLockToHide.gameObject.SetActive(false);
                handleToEnable.enabled = true;
            }

            keycardTransform = null;
        }

        private void Update()
        {
            if (keycardTransform != null)
            {
                Vector3 keycardUp = keycardTransform.forward;
                float dot = Vector3.Dot(keycardUp, Vector3.up);

                if (dot < 1 - allowedUprightErrorRange)
                {
                    swipeIsValid = false;
                }
            }
        }
    }
}