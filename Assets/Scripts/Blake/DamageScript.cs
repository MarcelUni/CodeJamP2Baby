using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
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
    void OnCollision(Collision collision)
    {
// 5
        if(collision.gameObject.name == "Car Name")
        {
// 6
            //AmbulanceLives -= 1;
            Debug.Log("Life lost");
        }
    }
    
}
