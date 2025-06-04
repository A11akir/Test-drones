using System.Collections;
using UnityEngine;

public class SpawnRes : MonoBehaviour
{
    [SerializeField] private GameObject resPrefab;

    [SerializeField] private SpawnMap spawnMap;
    [SerializeField] private DronAI dronAI;

    private int timeDelay = 2;

    private void Start()
    {
        StartCoroutine(SpawnerResCorutine());
    }

    private IEnumerator SpawnerResCorutine()
    {
        while(true)
        {
            SpawnerRes();
            dronAI.ReScan();
            yield return new WaitForSeconds(timeDelay);
        }
    }

    private void SpawnerRes()
    {
        Vector2 resPosition = spawnMap.GetRandomPosition();

        Instantiate(resPrefab, resPosition, Quaternion.identity);
    }
}
