using UnityEngine;

public class NPCSpawnSystem : MonoBehaviour
{
    public GameObject[] npcPrefabs; // Array of NPC prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points

    public float spawnInterval = 2f; // Time interval between spawns
    private float nextSpawnTime; // Time for the next spawn

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set initial spawn time
    }

    void Update()
    {
        // Check if it's time to spawn a new NPC
        if (Time.time >= nextSpawnTime)
        {
            SpawnNPC(); // Spawn a new NPC
            nextSpawnTime = Time.time + spawnInterval; // Set time for the next spawn
        }
    }

    void SpawnNPC()
    {
        // Choose a random NPC prefab from the npcPrefabs array
        GameObject npcPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];

        // Choose a random spawn point from the spawnPoints array
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the NPC at the chosen spawn point
        Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
    }
}
