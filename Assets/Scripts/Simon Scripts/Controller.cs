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
    public float laneChangeDuration = 0.5f; // Duration of lane change in seconds



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

        // Constrain rotation along the y-axis to always face forward
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

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
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }


    //JUMPING 
    void OnCollisionEnter(Collision other)
    {
        canJump = true; // Enable jumping when player lands
    }



       void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        float targetX = (newLane - 1) * laneWidth;
        StartCoroutine(MoveToLane(targetX));
        currentLane = newLane;
    }

    IEnumerator MoveToLane(float targetX)
    {
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        while (elapsedTime < laneChangeDuration)
        {
            // Smoothly move to the target lane position
            float newX = Mathf.Lerp(startPosition.x, targetPosition.x, elapsedTime / laneChangeDuration);
            float newZ = transform.position.z; // Maintain forward position
            transform.position = new Vector3(newX, transform.position.y, newZ);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that the player reaches the exact target position
        transform.position = targetPosition;
        }
    void Jump()
    {
        // Apply jump force
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false; // Disable jumping until player lands again
    }
}