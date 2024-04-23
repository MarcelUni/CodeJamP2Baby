using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ambulance")
        {
            GameManager.instance.RemoveHP();
            FuelManager.instance.AddFuel(10);
            Destroy(gameObject);
        }
    }

}
