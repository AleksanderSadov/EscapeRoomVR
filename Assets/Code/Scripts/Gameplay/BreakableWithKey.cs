using System;
using Unity.XRContent.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace EscapeRoom.Gameplay
{
    public class BreakableWithKey : MonoBehaviour
    {
        [Serializable] public class BreakEvent : UnityEvent<GameObject, GameObject> { }

        public bool shouldSpawnKey = false;

        [SerializeField]
        [Tooltip("The 'broken' version of this object.")]
        GameObject brokenVersion;

        [SerializeField]
        [Tooltip("The tag a collider must have to cause this object to break.")]
        string colliderTag = "Destroyer";

        [SerializeField]
        [Tooltip("Events to fire when a matching object collides and break this object. " +
            "The first parameter is the colliding object, the second parameter is the 'broken' version.")]
        BreakEvent onBreak = new BreakEvent();

        bool destroyed = false;

        public BreakEvent OnBreak => onBreak;

        private Keychain key;

        private void Start()
        {
            key = GetComponentInChildren<Keychain>(true);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (destroyed)
            {
                return;
            }
            if (collision.gameObject.tag.Equals(colliderTag, System.StringComparison.InvariantCultureIgnoreCase))
            {
                destroyed = true;
                var brokenVersion = Instantiate(this.brokenVersion, transform.position, transform.rotation);
                onBreak.Invoke(collision.gameObject, brokenVersion);

                if (shouldSpawnKey && key != null)
                {
                    key.gameObject.transform.parent = null;
                    key.gameObject.SetActive(true);
                }

                Destroy(gameObject);
            }
        }
    }
}
