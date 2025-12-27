using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public GameObject obstaclePrefab;

    [Header("Spawn Settings")]
    public float spawnDistance = 25f;
    public float minDistanceBetweenObstacles = 3f;
    public float maxDistanceBetweenObstacles = 7f;

    [Header("Lane Settings")]
    public float laneOffset = 2.5f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.position.z + spawnDistance;
    }

    void Update()
    {
        if (player.position.z + spawnDistance > nextSpawnZ)
        {
            SpawnObstacle();
            nextSpawnZ += Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);
        }
    }

    void SpawnObstacle()
    {
        int laneIndex = Random.Range(0, 3);
        float laneX = (laneIndex - 1) * laneOffset;

        Vector3 spawnPos = new Vector3(
            laneX,
            0.5f,
            nextSpawnZ
        );

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
