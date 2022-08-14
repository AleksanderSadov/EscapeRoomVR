using EscapeRoom.ScriptableObjects;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace EscapeRoom.Gameplay
{
    public class PlayerTeleportPoint : MonoBehaviour
    {
        public MainConfig playerRigConfig;

        private XROrigin playerRig;

        private void Start()
        {
            playerRig = FindObjectOfType<XROrigin>();
        }

        public void TeleportPlayer()
        {
            playerRig.transform.position = new Vector3(
                transform.position.x,
                transform.position.y + playerRigConfig.defaultPlayerRigHeightOffset,
                transform.position.z
            );
        }
    }
}
