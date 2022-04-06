using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private List<Obstacles> obstacles;
    [SerializeField] private Settings settings;
    [SerializeField] private float radius;
    private float _randomRadius => Random.Range(-radius, radius);
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        int countSpawned = 0;
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (!obstacles[i])
            {
                obstacles.RemoveAt(i);
                i--;
                continue;
            }
            if (i > settings.countObstacles) obstacles[i].gameObject.SetActive(false);

            obstacles[i].gameObject.SetActive(true);
            SetRandomPosition(obstacles[i].transform);


            countSpawned++;
        }
        for (int i = countSpawned; i < settings.countObstacles; i++)
        {
            obstacles.Add(Instantiate(obstacles[0]));
            SetRandomPosition(obstacles[i].transform);
        }
    }
    private void SetRandomPosition(Transform objectForSpawn)
    {
        Vector3 center = transform.position;
        objectForSpawn.position = new Vector3(center.x + _randomRadius, center.y, center.z + _randomRadius);
    }

}
