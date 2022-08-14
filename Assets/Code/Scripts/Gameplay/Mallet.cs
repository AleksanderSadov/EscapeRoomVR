using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace EscapeRoom.Gameplay
{
    public class Mallet : XRGrabInteractable
    {
        public UnityEvent selectedByInteractor; 

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (args.interactorObject is XRDirectInteractor || args.interactorObject is XRRayInteractor)
            {
                selectedByInteractor?.Invoke();
            }
        }
    }
}

