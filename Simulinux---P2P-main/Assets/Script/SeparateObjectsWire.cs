using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparateObjectsWire : MonoBehaviour
{
    //variables
    public GameObject WireStripper;
    public GameObject WireStripperExit;
    public float speed;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.T)) //keyboard input
            {
                Debug.Log("Object Separated");
                WireStripper.transform.position = Vector3.MoveTowards(WireStripper.transform.position, WireStripperExit.transform.position, speed);

            }
        }

    }
}
