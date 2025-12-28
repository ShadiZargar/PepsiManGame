using UnityEngine;

/*
 * ObstacleSpawner
 * Spawns obstacles ahead of the player at random distances
 * and randomly assigns them to one of three lanes.
 */
public class ObstacleSpawner : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject obstaclePrefab;

    public float spawnDistance = 25f;
    public float minDistanceBetween = 3f;
    public float maxDistanceBetween = 7f;

    public float laneOffset = 2.5f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = playerTransform.position.z + spawnDistance;
    }

    void Update()
    {
        if (playerTransform.position.z > nextSpawnZ - spawnDistance)
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

        Vector3 spawnPosition = new Vector3(
            laneX,
            0,
            nextSpawnZ
        );

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
