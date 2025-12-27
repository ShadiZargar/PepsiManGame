using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject obstaclePrefab;

    public float spawnDistance = 25f;
    public float minDistanceBetween = 3f;
    public float maxDistanceBetween = 7f;

    public float laneOffset = 2.5f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.position.z + spawnDistance;
    }

    void Update()
    {
        if (player.position.z > nextSpawnZ - spawnDistance)
        {
            SpawnObstacle();
            float randomGap = Random.Range(minDistanceBetween, maxDistanceBetween);
            nextSpawnZ += randomGap;
        }
    }

    void SpawnObstacle()
    {
        int laneIndex = Random.Range(-1, 2);
        float laneX = laneIndex * laneOffset;

        Vector3 spawnPos = new Vector3(
            laneX,
            0,
            nextSpawnZ
        );

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
