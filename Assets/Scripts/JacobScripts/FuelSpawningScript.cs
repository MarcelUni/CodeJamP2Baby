using UnityEngine;

public class FuelSpawningScript : MonoBehaviour
{
    public GameObject[] fuelPrefabs; // Array of fuel prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points

    public Transform playerTransform; // Reference to the player's transform
    public float despawnDistance = 50f; // Distance at which fuel objects are despawned

    public float minSpawnInterval = 7f; // Minimum time interval between spawns
    public float maxSpawnInterval = 15f; // Maximum time interval between spawns
    private float nextSpawnTime; // Time for the next spawn

    // Start is called before the first frame update
    void Start()
    {
        // Set initial spawn time to a random value between minSpawnInterval and maxSpawnInterval
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to spawn a new fuel object
        if (Time.time >= nextSpawnTime)
        {
            SpawnFuel(); // Spawn a new fuel object
            // Set time for the next spawn to a random value between minSpawnInterval and maxSpawnInterval
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }

        // Despawn fuel objects that are too far behind the player
        DespawnOldFuel();
    }

    // Method to spawn a new fuel object
    void SpawnFuel()
    {
        // Choose a random fuel prefab from the fuelPrefabs array
        GameObject fuelPrefab = fuelPrefabs[Random.Range(0, fuelPrefabs.Length)];

        // Choose a random spawn point from the spawnPoints array
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the fuel object at the chosen spawn point with a rotation of 180 degrees
        Instantiate(fuelPrefab, spawnPoint.position, Quaternion.Euler(0f, 180f, 0f));
    }

    // Method to despawn old fuel objects
    void DespawnOldFuel()
    {
        // Iterate through all spawned fuel objects
        foreach (GameObject fuelObject in GameObject.FindGameObjectsWithTag("Fuel"))
        {
            // Check if the fuel object is too far behind the player
            if (fuelObject.transform.position.z < playerTransform.position.z - despawnDistance)
            {
                Destroy(fuelObject); // Despawn the fuel object
            }
        }
    }
}
