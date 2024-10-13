using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireObjectScript : MonoBehaviour
{
    public GameObject WireObjectOnPlayer;
    public Camera cam1;
    public Camera cam2;

    // Start is called before the first frame update
    void Start()
    {
        WireObjectOnPlayer.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F)) //keyboard input
            {
                this.gameObject.SetActive(false);
                WireObjectOnPlayer.SetActive(true);
                Debug.Log("Wire object selected");
                cam1.enabled = false;
                cam2.enabled = true;            }
        }

    }



}
