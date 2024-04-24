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
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
            LeftLane();
            AudioManageryTest.instance.PlayTireScreech();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RightLane();
            AudioManageryTest.instance.PlayTireScreech();
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
        if(currentLane == 2)
            return;

        ChangeLane(1);
        anim.SetTrigger("Right");
    
    }

    public void LeftLane()
    {
        if(currentLane == 0)
            return;

        ChangeLane(-1);
        anim.SetTrigger("Left");
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