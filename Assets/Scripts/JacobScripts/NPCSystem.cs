using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private float speed = 5f; // Adjust this to control the speed of movement
    [SerializeField] private float explosionForce = 10f; // Adjust this to control the force of the explosion

    void Update()
    {
        // Move the object along its forward direction (in local space)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collider that was hit has a tag "Ambulance"
        if (collision.collider.CompareTag("Ambulance"))
        {
            // Calculate a random direction for the explosion
            Vector3 explosionDirection = Random.onUnitSphere;
            explosionDirection.y = Mathf.Abs(explosionDirection.y); // Ensure the direction is in the upper half


            // Apply force to the object in the random direction
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                boxCollider.enabled = false;
                rb.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
            }

            // You can add any other actions or behaviors here
            Debug.Log("Object hit an obstacle and exploded!");
        }
    }
}
