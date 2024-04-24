using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    
    string[] smallVehicles = {"small_car(Clone)", "sport_car(Clone)", "taxi(Clone)", "blue_car(Clone)", "Hatchback(Clone)", "Sedan(Clone)"};
    string[] largeVehicles = {"truck(Clone)", "small_bus(Clone)", "bus(Clone)"};
    
    private void OnCollisionEnter(Collision collision)
    {
        AudioManageryTest.instance.PlaySFX("CrashLoseHP");
        
        if(collision.gameObject.name == "small_car(Clone)" || 
           collision.gameObject.name == "sport_car(Clone)" || 
           collision.gameObject.name == "taxi(Clone)" || 
           collision.gameObject.name == "blue_car(Clone)" || 
           collision.gameObject.name == "Hatchback(Clone)" || 
           collision.gameObject.name == "Sedan(Clone)")
        { 
            GameManager.instance.RemoveHP(1);
            Debug.Log("Life lost");
        }
        else if (collision.gameObject.name == "truck(Clone)" || 
                 collision.gameObject.name == "small_bus(Clone)" || 
                 collision.gameObject.name == "bus(Clone)")
        {
            GameManager.instance.RemoveHP(2);
            Debug.Log("Two Lives lost");
        }
    }
    
}
