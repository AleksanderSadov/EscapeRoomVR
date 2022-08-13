using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace EscapeRoom.Gameplay
{

    public class DoorHandle : XRBaseInteractable
    {
        [Header("Door Handle Data")]
        public Transform draggedTransform;
        public Vector3 localDragDirection;
        public float dragDistance;
        public int doorWeight = 20;

        private Vector3 startPosition;
        private Vector3 endPosition;
        private Vector3 worldDragDirection;

        private void Start()
        {
            worldDragDirection = transform.TransformDirection(localDragDirection).normalized;

            startPosition = draggedTransform.position;
            endPosition = startPosition + worldDragDirection * dragDistance;
        }

        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
        {
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed && isSelected)
            {
                var interactorTransform = firstInteractorSelecting.GetAttachTransform(this);
                Vector3 selfToInteractor = interactorTransform.position - transform.position;
                float forceInDirectionOfDrag = Vector3.Dot(selfToInteractor, worldDragDirection);
                bool dragToEnd = forceInDirectionOfDrag > 0.0f;
                float absoluteForce = Mathf.Abs(forceInDirectionOfDrag);
                float speed = absoluteForce / Time.deltaTime / doorWeight;
                draggedTransform.position = Vector3.MoveTowards(
                    draggedTransform.position,
                    dragToEnd ? endPosition : startPosition,
                    speed * Time.deltaTime
                );
            }
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 worldDirection = transform.TransformDirection(localDragDirection);
            worldDirection.Normalize();

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + worldDirection * dragDistance);
        }
    }
}