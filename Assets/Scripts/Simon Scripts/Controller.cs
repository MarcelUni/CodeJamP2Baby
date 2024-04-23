using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

  {
    public float forwardSpeed = 5f; // Speed of forward movement
    public float jumpForce = 10f; // Force of the jump
    public float sideSpeed = 2f; // Speed of sideways movement
    public float laneWidth = 2f; // Width of each lane
    private int currentLane = 1; // Current lane index (0, 1, 2)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        float targetX = (newLane - 1) * laneWidth;
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        currentLane = newLane;
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