using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public float spawnX = 8;
    public float spawnY = 4.5f;

    private List<Vector2> availablePositions = new List<Vector2>();

    private void Awake()
    {
        GeneratePositions();
    }

    public void GeneratePositions()
    {
        for (float x = -spawnX; x <= spawnX; x++)
        {
            for (float y = -spawnY; y <= spawnY; y++)
            {
                availablePositions.Add(new Vector2(x, y));
            }
        }
    }

    public Vector2 GetRandomPosition()
    {
        if (availablePositions.Count == 0)
        {
            GeneratePositions();
        }

        int index = Random.Range(0, availablePositions.Count);
        Vector2 chosen = availablePositions[index];

        availablePositions.RemoveAt(index);

        return chosen;
    }
}
