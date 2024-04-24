using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public float forwardSpeed = 10f; // Speed of forward movement
    public float jumpForce = 10f; // Force of the jump
    public float laneWidth = 2f; // Width of each lane
    private int currentLane = 1; // Current lane index (0, 1, 2)
    private int targetLane = 1; // Target lane for lane change
    public float laneChangeSpeed = 0.5f; // Duration of lane change in seconds

    private Rigidbody rb;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

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
        
        // Move left/right with A/D keys
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeLane(1);
        }

        // Jump with Space key
        if (canJump)
        {   
            if(Input.GetKeyDown(KeyCode.Space) || Input.acceleration.y > 0.5)
                Jump();
        }
    }

    public void RightLane()
    {
        ChangeLane(1);
    }

    public void LeftLane()
    {
        ChangeLane(-1);
    }

    //JUMPING 
    void OnCollisionEnter(Collision other)
    {
        canJump = true; // Enable jumping when player lands
    }
    void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetLane = newLane;
    }
    void Jump()
    {
        // Apply jump force
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false; // Disable jumping until player lands again
    }
}