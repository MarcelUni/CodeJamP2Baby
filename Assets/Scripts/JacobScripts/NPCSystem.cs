using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
 public float speed = 5f; // Adjust this to control the speed of movement

    void Update()
    {
        // Move the object along its forward direction (in local space)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
