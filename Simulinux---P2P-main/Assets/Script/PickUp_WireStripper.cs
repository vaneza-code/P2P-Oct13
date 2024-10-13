using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireStripperScript : MonoBehaviour
{
    public GameObject WireStripperOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        WireStripperOnPlayer.SetActive(false);
        
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E)) //keyboard input
            {
                this.gameObject.SetActive(false);
                WireStripperOnPlayer.SetActive(true);
                Debug.Log("Wire stripper selected");
            }
        }
    
    }



}
