using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    
    string[] smallVehicles = {"small_car(Clone)", "sport_car(Clone)", "taxi(Clone)", "blue_car(Clone)", "Hatchback(Clone)", "Sedan(Clone)"};
    string[] largeVehicles = {"truck(Clone)", "small_bus(Clone)", "bus(Clone)"};
    
    public static DamageScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            
    }
    void VehicleDamage(Collision collision)
    {
        
        if(collision.gameObject.name == smallVehicles[0] || 
           collision.gameObject.name == smallVehicles[1] || 
           collision.gameObject.name == smallVehicles[2] || 
           collision.gameObject.name == smallVehicles[3] || 
           collision.gameObject.name == smallVehicles[4] || 
           collision.gameObject.name == smallVehicles[5])
        { 
            GameManager.instance.RemoveHP();
            Debug.Log("Life lost");
        }
        else if (collision.gameObject.name == largeVehicles[0] || 
                 collision.gameObject.name == largeVehicles[1] || 
                 collision.gameObject.name == largeVehicles[2])
        {
            GameManager.instance.RemoveHP();
            Debug.Log("Two Lives lost");
        }
    }
    
}
