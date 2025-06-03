using UnityEngine;

public class SpawnDron : MonoBehaviour
{
    [SerializeField] private GameObject dronBluePrefab;
    [SerializeField] private GameObject dronRedPrefab;
    
    private int maxDronCount = 5;
    
    private float CoordinateSpawnX = 8;
    private float CoordinateSpawnY = 4.5f;

    private void Start()
    {
        SpawnDrons(maxDronCount);
    }

    private void SpawnDrons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 blueDronPosition = new Vector2(
                Random.Range(-CoordinateSpawnX, CoordinateSpawnX),
                Random.Range(-CoordinateSpawnY, CoordinateSpawnY)
            );
            
            Vector2 redDronPosition = new Vector2(
                Random.Range(-CoordinateSpawnX, CoordinateSpawnX),
                Random.Range(-CoordinateSpawnY, CoordinateSpawnY)
            );
            
            Instantiate(dronBluePrefab, blueDronPosition, Quaternion.identity);
            
            Instantiate(dronRedPrefab, redDronPosition, Quaternion.identity);
        }
    }
}
