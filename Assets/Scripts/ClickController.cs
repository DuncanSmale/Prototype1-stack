using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    private Transform selected = null; //object that was clicked on
    private Vector4 offsetExtents; //bounds for movement: x = left, y = right, z = up, w = down.

    [SerializeField] private LayerMask layerMask; //layermask to change which layer the ray cast will be performed on
    float aspectRatio;

    float camSize;

    void Start()
    {
        camSize = Camera.main.orthographicSize; //the orthographic size of the camera
        aspectRatio = Camera.main.aspect; //gets the camera property of the ratio, which is width divided by height
    }

    // Update is called once per frame
    void Update()
    {
        HandleClick();//function to handle what happens when the player clicks
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(selected != null)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //takes the mouse position and transforms it into world co-ordinates.
            Vector2 selectedBounds = selected.GetComponentInChildren<Collider>().bounds.extents;//gets the colliders bounds 
            //Vector4 ext = CalculateExtents();
            float offsetx = ((offsetExtents.x + offsetExtents.y) % 2) == 0 ? 0.5f : 0; //sets the offsetx for odd bounded objects
            float offsety = ((offsetExtents.z + offsetExtents.w) % 2) == 0 ? 0.5f : 0; //sets offset y 

            float x = Mathf.Clamp((Mathf.RoundToInt(newPos.x) + offsetx), 
                -(int)(camSize * aspectRatio - offsetExtents.y) - 1f, 
                (int)(camSize * aspectRatio - offsetExtents.x) - 1f); //creates a clamped value

            float y = Mathf.Clamp((Mathf.RoundToInt(newPos.y) + offsety),
                -(camSize - offsetExtents.w), 
                (camSize - offsetExtents.z)); //creates a clamped value
            newPos = new Vector3(x, y, 0); //sets the objects transform in a new vector to make z value 0
            selected.position = newPos; //sets objects postion
        }
    }

    void CalculateExtents() //calculates the offset 
    {
        Vector4 extents = new Vector2();
        Vector4 temp = extents;
        Vector2 objCenter = selected.transform.position;
        foreach (Collider ext in selected.GetComponentsInChildren<Collider>())
        {            
            Bounds bound = ext.bounds;
            float extentLeft = (objCenter.x - bound.center.x) + bound.extents.x;
            float extentRight = (bound.center.x - objCenter.x) + bound.extents.x;
            float extentUp = (bound.center.y - objCenter.y) + bound.extents.y;
            float extentDown = (objCenter.y - bound.center.y) + bound.extents.y;
            temp = new Vector4(extentLeft, extentRight, extentUp, extentDown);
            extents.x = temp.x > extents.x ? temp.x : extents.x;
            extents.y = temp.y > extents.y ? temp.y : extents.y;
            extents.z = temp.z > extents.z ? temp.z : extents.z;
            extents.w = temp.w > extents.w ? temp.w : extents.w;
        }
        offsetExtents = extents;
    }

    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(selected == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide))
                {
                    selected = hitInfo.transform.parent;
                    selected.GetComponent<Object>().Pickup();
                    CalculateExtents();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selected != null)
            {
                selected.GetComponent<Object>().Placed();
                selected = null;
                offsetExtents = Vector4.zero;
            }
        }
    }
}
