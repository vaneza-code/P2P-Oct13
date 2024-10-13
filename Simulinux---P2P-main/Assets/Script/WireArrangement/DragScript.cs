using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    public delegate void DragEndedDelegate(Transform transform); // Delegate for drag end event
    public DragEndedDelegate dragEndedDelegate; // Reference to the delegate
    Camera cam;
    Vector3 offset;
    bool holding;
    float zDepth;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // Get the main camera
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zDepth;
            Vector3 newPos = cam.ScreenToWorldPoint(mousePos) + offset; // Calculate new position
            transform.position = newPos; // Move the wire

            // Log the position of the wire while dragging for debugging
            Debug.Log($"Dragging {transform.name} at position: {transform.position}");
        }
    }

    private void OnMouseDown()
    {
        holding = true; // Set the holding state to true
        zDepth = cam.WorldToScreenPoint(transform.position).z; // Get the z-depth of the object
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zDepth;
        offset = transform.position - cam.ScreenToWorldPoint(mousePos); // Calculate offset
    }

    private void OnMouseUp()
    {
        holding = false; // Set holding to false
        if (dragEndedDelegate != null) // Ensure the delegate is not null
        {
            dragEndedDelegate(this.transform); // Call the snap logic
        }
    }
}
