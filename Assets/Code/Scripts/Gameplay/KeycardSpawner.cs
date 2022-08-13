using UnityEngine;

namespace EscapeRoom.Gameplay
{
    public class KeycardSpawner : MonoBehaviour
    {
        public GameObject keyCardPrefab;

        public void SpawnKeyCard()
        {
            var keycard = Instantiate(keyCardPrefab);
            keycard.transform.position = transform.position;
        }
    }
}