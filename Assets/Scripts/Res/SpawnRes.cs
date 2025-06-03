using UnityEngine;

public class SpawnRes : MonoBehaviour
{
    [SerializeField] private GameObject resPrefab;

    private int maxDronCount = 5;

    private void Start()
    {
        for (int i = 0; i < maxDronCount; i++)
        {
            Instantiate(resPrefab, transform);
        }
        
    }
}
