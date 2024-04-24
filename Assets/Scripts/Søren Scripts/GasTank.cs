using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class GasTank : MonoBehaviour
{
    public float fuelAmount = 10f; // Mængden af benzin bilen får den rammer en benzin dunk.

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
    


