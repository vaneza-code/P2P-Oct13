using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireDrag : MonoBehaviour
{
    public Transform hiddenEnd;  // Reference to the hidden part of the wire

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the hidden end so that it stays in place
        initialPosition = hiddenEnd.position;
    }

    void OnMouseDrag()
    {
        // Move the exposed part with the mouse
        Vector3 newPosition = GetMouseWorldPosition();
        transform.position = newPosition;

        // Keep the hidden part fixed by resetting its position
        hiddenEnd.position = initialPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position and convert it to world space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;  // Get distance to camera
        return Camera.main.ScreenToWorldPoint(mousePos);  // Convert to world position
    }
}
