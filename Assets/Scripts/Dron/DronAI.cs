using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DronAI : MonoBehaviour
{
    [SerializeField] private SpawnMap spawnMap;
    [SerializeField] private SpawnDron spawnDron;
    [SerializeField] private float moveSpeed = 2f;

    private List<Transform> allRes;

    public List<Transform> GetTransformsWithResInArea()
    {
        List<Transform> result = new List<Transform>();
        ResTag[] allResComponents = FindObjectsOfType<ResTag>();

        foreach (ResTag res in allResComponents)
        {
            Transform tf = res.transform;
            Vector2 pos = tf.position;

            if (pos.x >= -spawnMap.spawnX && pos.x <= spawnMap.spawnX &&
                pos.y >= -spawnMap.spawnY && pos.y <= spawnMap.spawnY)
            {
                result.Add(tf);
            }
        }

        return result;
    }

    public void ReScan()
    {
        allRes = GetTransformsWithResInArea();
        DroneMove();
    }

    public GameObject GetClosestDrone(List<GameObject> drones, Transform resource)
    {
        GameObject closestDrone = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject drone in drones)
        {
            if (drone == null) continue;

            float dist = Vector3.Distance(drone.transform.position, resource.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closestDrone = drone;
            }
        }

        return closestDrone;
    }

    public void DroneMove()
    {
        var resList = GetTransformsWithResInArea();

        if (resList == null || resList.Count == 0)
        {
            Debug.LogWarning("Нет ресурсов на сцене.");
            return;
        }

        if (spawnDron == null || spawnDron.drons == null || spawnDron.drons.Count == 0)
        {
            Debug.LogWarning("Нет дронов для перемещения.");
            return;
        }

        Transform targetRes = resList[0];
        GameObject nearDrone = GetClosestDrone(spawnDron.drons, targetRes);

        if (nearDrone == null)
        {
            Debug.LogWarning("Не найден ближайший дрон.");
            return;
        }

        float distance = Vector3.Distance(nearDrone.transform.position, targetRes.position);
        float duration = distance / moveSpeed; // Рассчитываем время, исходя из скорости

        nearDrone.transform.DOMove(targetRes.position, duration);
    }
}

