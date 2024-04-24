using UnityEngine;

public class KeepSpawnPointFixedDistance : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float fixedZDistance = 10f; // Desired fixed Z distance from the player

    void LateUpdate()
    {
        // Get the current position of the spawn point
        Vector3 currentPosition = transform.position;

        // Calculate the target position with the fixed Z distance from the player
        Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y, playerTransform.position.z + fixedZDistance);

        // Update the position of the spawn point to maintain the fixed Z distance from the player
        transform.position = targetPosition;
    }
}
