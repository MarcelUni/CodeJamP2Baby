using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] spawnObject; // Array of fuel prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points

    public Transform playerTransform; // Reference to the player's transform
    public float despawnDistance = 50f; // Distance at which fuel objects are despawned

    protected float nextSpawnTime; // Time for the next spawn


}
