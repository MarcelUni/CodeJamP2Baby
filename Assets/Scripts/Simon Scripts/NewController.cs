using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";
    public string moveL = "a";
    public string moveR = "d";  





    
  // Use this for initialization
void Start () {
}
// Update is called once per frame
void Update () {
        GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, 4);

        if ((Input.GetKeyDown(KeyCode.A)) && (laneNum>1)&& (controlLocked == "n"))
        {
        horizVel = -2;
        StartCoroutine (stopSlide ());
        laneNum -= 1;
        controlLocked = "y";
        }
        

        if ((Input.GetKeyDown(KeyCode.D))&& (laneNum<3)&& (controlLocked == "n"))
        {

            horizVel = 2;
            StartCoroutine (stopSlide ());
            laneNum += 1;
            controlLocked = "y";
        }
}


    IEnumerator stopSlide()
        {
        yield return new WaitForSeconds (1f);
        horizVel = 0;
        controlLocked = "n";
        }

}
