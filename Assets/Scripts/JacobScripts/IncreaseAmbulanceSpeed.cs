using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAmbulanceSpeed : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] private GameObject movingObject; // Reference to the object that moves
    private Vector3 previousPosition;

    private void Start()
    {
        // Initialize previousPosition to the initial position of the moving object
        previousPosition = movingObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance moved since the last frame
        float distanceMoved = Vector3.Distance(movingObject.transform.position, previousPosition);

        // Increment speed based on distance moved
        controller.forwardSpeed += distanceMoved * Time.deltaTime;

        // Update previous position for the next frame
        previousPosition = movingObject.transform.position;
    }
}
