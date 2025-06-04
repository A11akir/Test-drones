using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnDron : MonoBehaviour
{
    [SerializeField] private GameObject dronBluePrefab;
    [SerializeField] private GameObject dronRedPrefab;

    [SerializeField] private SpawnMap spawnMap;

    private int maxDronCount = 5;
    
    [HideInInspector] public List<GameObject> dronsBlue;
    [HideInInspector] public List<GameObject> dronsRed;
    [HideInInspector] public List<GameObject> drons;

    private void Start()
    {
        SpawnDrons(maxDronCount);

        drons = dronsBlue.Concat(dronsRed).ToList();
    }

    private void SpawnDrons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 blueDronPosition = spawnMap.GetRandomPosition();
            Vector2 redDronPosition = spawnMap.GetRandomPosition();
            
            var dronBlue = Instantiate(dronBluePrefab, blueDronPosition, Quaternion.identity);
            var dronRed = Instantiate(dronRedPrefab, redDronPosition, Quaternion.identity);

            dronsBlue.Add(dronBlue);
            dronsRed.Add(dronRed);

        }
    }
}
