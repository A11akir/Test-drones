using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDron : MonoBehaviour
{
    [SerializeField] private GameObject dronPrefab;
    private int maxDronCount = 5;

    private void Start()
    {
        for (int i = 0; i < maxDronCount; i++)
        {
            Instantiate(dronPrefab, transform);
        }
        
    }
}
