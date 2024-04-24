using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private float speed = 5f; // Adjust this to control the speed of movement
    [SerializeField] private float explosionForce = 10f; // Adjust this to control the force of the explosion
    [SerializeField] private GameObject explosionParticlesPrefab; // Reference to the particle system prefab

    public float laneWidth = 2f; // Width of each lane
    private int currentLane = 1; // Current lane index (0, 1, 2)
    private int targetLane = 1; // Target lane for lane change
    public float laneChangeSpeed = 50f; // Duration of lane change in seconds
    public bool isCollidingWithTrigger = false;

    public int randomLane1 = -1;
    public int randomLane2 = 3;

    private bool switchingLanes = false;
    private bool blinkLeft;
    private bool blinkRight;
    [SerializeField] private GameObject lightLeft;
    [SerializeField] private GameObject lightRight;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();

        lightLeft.SetActive(false);
        lightRight.SetActive(false);

        // Randomly choose a lane index between -1 and 3
        int randomLaneIndex = Random.Range(randomLane1, randomLane2);

        // Change to the randomly selected lane index
        ChangeLane(randomLaneIndex);


    }


    void FixedUpdate()
    {
        // Move the object along its forward direction (din local space)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (currentLane != targetLane)
        {
            float targetX = (targetLane - 1) * laneWidth;
            float newX = Mathf.MoveTowards(transform.position.x, targetX, laneChangeSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // If the player reached the target lane, update the current lane
            if (Mathf.Approximately(transform.position.x, targetX))
            {
                currentLane = targetLane;
            }
        }

        if (switchingLanes == false && isCollidingWithTrigger == false)
        {
            float randomTime = Random.Range(0, 350);

            // Move left/right with A/D keys
            if (randomTime == 250 && currentLane != 2)
            {
                switchingLanes = true;
                blinkLeft = true;
                blinkRight = false;
                StartCoroutine(BlinkLeftRight());
            }
            else if (randomTime == 125 && currentLane != 0)
            {
                switchingLanes = true;
                blinkLeft = false;
                blinkRight = true;
                StartCoroutine(BlinkLeftRight());
            }
        }


    }

    void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetLane = newLane;
        switchingLanes = false;
    }


    // You can use this method to check if the trigger collider is currently colliding with another trigger collider
    public bool IsCollidingWithTrigger()
    {
        return isCollidingWithTrigger;
    }

    private IEnumerator BlinkLeftRight()
    {
        if (blinkLeft)
        {
            yield return new WaitForSeconds(0.5f);
            lightLeft.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            lightLeft.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            lightLeft.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            lightLeft.SetActive(false);
            ChangeLane(1);
        }
        else if (blinkRight)
        {
            yield return new WaitForSeconds(0.5f);
            lightRight.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            lightRight.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            lightRight.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            lightRight.SetActive(false);
            ChangeLane(-1);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collider that was hit has a tag "Ambulance"
        if (collision.collider.CompareTag("Ambulance"))
        {
            // Calculate a random direction for the explosion in the upper half sphere
            Vector3 explosionDirection = Random.onUnitSphere;
            explosionDirection.y = Mathf.Abs(explosionDirection.y); // Ensure the direction is in the upper half

            // Apply force to the object in the random direction
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {

                rb.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
                collider.enabled = false;
            }

            // Instantiate and play the particle system
            if (explosionParticlesPrefab != null)
            {
                Instantiate(explosionParticlesPrefab, collision.contacts[0].point, Quaternion.identity);
                gameManager.RemoveHP();
            }

            // You can add any other actions or behaviors here
            Debug.Log("Object hit an Ambulance and exploded!");
        }
    }
}

