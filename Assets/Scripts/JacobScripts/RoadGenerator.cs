using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadPrefab; // Prefab of the road segment
    public Transform playerTransform; // Reference to the player's transform
    public float segmentLength = 10f; // Length of each road segment
    public int initialSegments = 5; // Number of initial road segments
    public float despawnDistance = 50f; // Distance at which road segments are despawned
    public float spawnDistanceThreshold = 10f; // Distance threshold for spawning new road segments
    public float spawnYPosition = -3.293912f; // Y level at which road segments spawn

    private Transform lastSegmentEnd; // Transform of the end of the last road segment

    void Start()
    {
        // Spawn initial road segments
        for (int i = 0; i < initialSegments; i++)
        {
            SpawnRoadSegment();
        }
    }

    void Update()
    {
        // Check if the player is close enough to the end of the last segment to spawn a new one
        if (Vector3.Distance(playerTransform.position, lastSegmentEnd.position) < spawnDistanceThreshold)
        {
            SpawnRoadSegment(); // Spawn a new road segment
        }

        // Despawn road segments that are too far behind the player
        DespawnOldSegments();
    }

    void SpawnRoadSegment()
    {
        // Instantiate a new road segment
        GameObject newSegment = Instantiate(roadPrefab, transform);

        // Position the new segment at the end of the last segment
        if (lastSegmentEnd != null)
        {
            newSegment.transform.position = lastSegmentEnd.position + Vector3.forward * segmentLength;
        }
        else
        {
            newSegment.transform.position = transform.position;
        }

        // Set the Y position of the new segment
        Vector3 newPosition = newSegment.transform.position;
        newPosition.y = spawnYPosition;
        newSegment.transform.position = newPosition;

        // Update the reference to the end of the last segment
        lastSegmentEnd = newSegment.transform;
    }

    void DespawnOldSegments()
    {
        // Iterate through all child objects (road segments)
        foreach (Transform child in transform)
        {
            // Check if the segment is too far behind the player
            if (child.position.z < playerTransform.position.z - despawnDistance)
            {
                Destroy(child.gameObject); // Despawn the segment
            }
        }
    }
}
