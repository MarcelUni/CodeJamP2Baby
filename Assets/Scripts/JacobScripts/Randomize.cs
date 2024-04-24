using System.Collections;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    [SerializeField] private float minX = -5f; // Minimum x-coordinate
    [SerializeField] private float maxX = 5f; // Maximum x-coordinate

    private void Awake()
    {
        // Generate a random position within the specified range
        float randomX = Random.Range(minX, maxX);

        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Set the new x-coordinate in the current position
        currentPosition.x = randomX;

        // Update the object's position
        transform.position = currentPosition;
    }
}
