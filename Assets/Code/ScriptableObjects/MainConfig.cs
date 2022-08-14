using UnityEngine;

namespace EscapeRoom.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "ScriptableObjects/MainConfig", order = 1)]
    public class MainConfig : ScriptableObject
    {
        [Header("Player")]
        public float defaultPlayerRigHeightOffset = 0.24f;
    }
}

