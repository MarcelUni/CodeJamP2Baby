using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class GasTank : MonoBehaviour
{
    public float fuelAmount = 10f; // M�ngden af benzin bilen f�r den rammer en benzin dunk.


    public float laneWidth = 2f; // Width of each lane
    private int currentLane = 1; // Current lane index (0, 1, 2)
    public bool isCollidingWithTrigger = false;
    private int targetLane = 1; // Target lane for lane change
    public float laneChangeSpeed = 50f; // Duration of lane change in seconds

    public int randomLane1 = 0;
    public int randomLane2 = 2;

    private void Start()
    {
        // Randomly choose a lane index between -1 and 3
        int randomLaneIndex = Random.Range(randomLane1, randomLane2);

        // Change to the randomly selected lane index
        ChangeLane(randomLaneIndex);

    }

    void FixedUpdate()
    {
        // Move the object along its forward direction (din local space)
        transform.Translate(Vector3.forward * 0f * Time.deltaTime);

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
    }

        void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetLane = newLane;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ambulance")
        {
            //Find the fuelmanager script and add fuelAmount to the current fuel
            FuelManager fuelManager = FindObjectOfType<FuelManager>();
            if (fuelManager != null)
            {
                fuelManager.CurrentFuel += fuelAmount;
            }
            //Destroy the gas tank
            Destroy(gameObject);

            Debug.Log("Fuel added: " + fuelAmount);
        }
    }
}
    


