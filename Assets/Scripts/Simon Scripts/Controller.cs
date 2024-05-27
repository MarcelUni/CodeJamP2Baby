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
    public bool canJump;
    private Animator anim;
    private bool canCheck;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        canJump = true;
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
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RightLane();
        }

        // Jump with Space key and accelerometer 
        if (canJump)
        {   
            if(Input.GetKeyDown(KeyCode.Space) || Input.acceleration.y > 0.4 || Input.acceleration.z > 0.4)
            {
                canJump = false; 
                canCheck = false;
                Jump();
                StartCoroutine(WaitCheck());
            }
        }    
    }

    IEnumerator WaitCheck()
    {
        yield return new WaitForSeconds(0.5f);
        canCheck = true;
    }

    public void RightLane()
    {
        if(currentLane == 2)
            return;

        ChangeLane(1);
        
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Right"))
            return;

        anim.SetTrigger("Right");
        AudioManageryTest.instance.PlayTireScreech("TireScreech4");
    }

    public void LeftLane()
    {
        if(currentLane == 0)
            return;

        ChangeLane(-1);

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Left"))
            return;

        anim.SetTrigger("Left");
        AudioManageryTest.instance.PlayTireScreech("TireScreech2");
    }

    //JUMPING 
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground") && canCheck == true)
            canJump = true;
    }
    void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetLane = newLane;
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger collider overlaps with an NPC collider
        if (other.CompareTag("Hospital"))
        {
            if (forwardSpeed != 65)
            {
                ScenesManager.instance.LoadScene("Win Cutscene");
            }
            if (forwardSpeed == 65)
            {
                ScenesManager.instance.LoadScene("Win CutsceneNight");

            }  
        }
    }
}