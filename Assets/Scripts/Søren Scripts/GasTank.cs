using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class GasTank : MonoBehaviour
{
    public float fuelAmount = 10f; // Mængden af benzin bilen får den rammer en benzin dunk.


    public float laneWidth = 2f; // Width of each lane
    private int currentLane = 1; // Current lane index (0, 1, 2)
    public bool isCollidingWithTrigger = false;

    public int randomLane1 = -1;
    public int randomLane2 = 3;

    // Update is called once per frame
    private void Start()
    {
        // Randomly choose a lane index between -1 and 3
        int randomLaneIndex = Random.Range(randomLane1, randomLane2);

        // Change to the randomly selected lane index
        ChangeLane(randomLaneIndex);

    }

    void ChangeLane(int direction)
    {
        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
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
    


