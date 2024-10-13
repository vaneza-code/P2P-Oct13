using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour
{
    //variables
    public GameObject WireStripper;
    public GameObject WireObject;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
 
    
    }
    // Update is called once per frame
    void Update()
    {
        //made changes with transform.position
        WireObject.transform.position = Vector3.MoveTowards(WireObject.transform.position, WireStripper.transform.position, speed);

    }
}
