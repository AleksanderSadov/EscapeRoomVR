using Unity.XRContent.Interaction;
using UnityEngine;

namespace EscapeRoom.Gameplay
{
    public class KeySpawner : MonoBehaviour
    {
        private int randomIndex;
        private BreakableWithKey[] breakables;

    private void Start()
        {
            FindAllKeysInScene();
            SetRandomKey();
        }

        private void FindAllKeysInScene()
        {
            breakables = FindObjectsOfType<BreakableWithKey>(true);
        }

        private void SetRandomKey()
        {
            randomIndex = Random.Range(0, breakables.Length);
            breakables[randomIndex].shouldSpawnKey = true;
        }
    }
}

