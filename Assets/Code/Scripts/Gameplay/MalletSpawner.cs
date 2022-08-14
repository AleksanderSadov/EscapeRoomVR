using System.Collections.Generic;
using UnityEngine;

public class MalletSpawner : MonoBehaviour
{
    private List<GameObject> spawnPoints = new List<GameObject>();

    private void Start()
    {
        GetChildSpawnPoints();
        DeactivateAllSpawnPoints();
        ActivateRandomSpawnPoint();
    }

    private void GetChildSpawnPoints()
    {
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child.gameObject);
        }
    }

    private void DeactivateAllSpawnPoints()
    {
        foreach (GameObject spawn in spawnPoints)
        {
            foreach (Transform child in spawn.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void ActivateRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        foreach (Transform child in spawnPoints[randomIndex].transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
