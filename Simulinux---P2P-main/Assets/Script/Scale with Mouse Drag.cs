using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class ScalewithMouseDrag : MonoBehaviour
{
    public Transform WorldAnchor;

    private Camera mainCamera;
    private float CameraZDistance;
    private Vector3 InitialScale;

    // Start is called before the first frame update
    private void Start()
    {
        InitialScale = transform.localScale;
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;

    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        //get mouse position in world space
        Vector3 MouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.x, CameraZDistance);
        Vector3 MouseWorldPosition = mainCamera.ScreenToWorldPoint(MouseScreenPosition);

        //change transform
        float distance = Vector3.Distance(WorldAnchor.position, MouseWorldPosition); //changes scale
        transform.localScale = new Vector3(InitialScale.x, distance / 2f, InitialScale.z);

        Vector3 middlePoint = (WorldAnchor.position + MouseWorldPosition) / 2f; //changes position
        transform.position = middlePoint;

        Vector3 rotationDirection = (MouseWorldPosition - WorldAnchor.position); //changes rotation
        transform.up = rotationDirection;

    }
}