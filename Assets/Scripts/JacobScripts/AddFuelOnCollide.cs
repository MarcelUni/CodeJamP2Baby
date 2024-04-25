using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuelOnCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ambulance")
        {
            FuelManager.instance.AddFuel(10);
            Destroy(gameObject);
        }
    }
}
