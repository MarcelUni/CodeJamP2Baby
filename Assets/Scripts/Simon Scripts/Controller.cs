using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
     public float forwardSpeed = 5f; // Speed of forward movement
    public float jumpForce = 10f; // Force of the jump
    public float sideSpeed = 2f; // Speed of sideways movement
    public float laneWidth = 3f; // Width of each lane
    public float laneChangeDuration = 0.5f; // Duration of lane change animation
    private int currentLane = 1; // Current lane index (0, 1, 2)

    private Rigidbody rb;
    private bool isChangingLane = false;
    private float laneChangeTimer = 0f;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
    }

    void Update()
    {
        // Move forward constantly
         transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Move left/right with A/D keys
        if (!isChangingLane && Input.GetKeyDown(KeyCode.A))
        {
            ChangeLane(-1);
        }
        else if (!isChangingLane && Input.GetKeyDown(KeyCode.D))
        {
            ChangeLane(1);
        }

        // Jump with Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Update lane change animation 
        if (isChangingLane)
        {
            laneChangeTimer += Time.deltaTime;
            if (laneChangeTimer > laneChangeDuration)
            {
                laneChangeTimer = 0f;
                isChangingLane = false;
            }
            else
            {
                float t = laneChangeTimer / laneChangeDuration;
                transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            }
        }
    }

// smooth lane change 

void ChangeLane(int direction)
{
    int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
    float targetX = newLane * laneWidth - laneWidth; // Adjusting for lane width
    targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
    currentLane = newLane;
    isChangingLane = true;
}

    void Jump()
    {
        // Check if the player is on the ground
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            // Apply jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}