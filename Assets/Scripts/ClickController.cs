using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{

    private Vector3 position; //position of the object that is clicked on
    private Transform selected = null; //object that was clicked on
    [SerializeField] private LayerMask layerMask; //layermask to change which layer the ray cast will be performed on
    [SerializeField] float aspectRatio;

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
            Vector2 selectedBounds = selected.GetComponent<Collider>().bounds.extents;//gets the colliders bounds 
            float offsetx = ((selectedBounds.x * 2) % 2) == 0 ? 0 : 0.5f; //sets the offsetx for odd bounded objects
            float offsety = ((selectedBounds.y * 2) % 2) == 0 ? 0 : 0.5f; //sets offset y 
            float x = Mathf.Clamp((Mathf.RoundToInt(newPos.x) + offsetx), -(int)(camSize * aspectRatio - selectedBounds.x) + 0.5f, (int)(camSize * aspectRatio - selectedBounds.x) - 0.5f); //creates a clamped value
            float y = Mathf.Clamp((Mathf.RoundToInt(newPos.y) + offsety), -(camSize - selectedBounds.y), (camSize - selectedBounds.y)); //creates a clamped value
            newPos = new Vector3(x, y, 0); //sets the objects transform in a new vector to make z value 0
            selected.position = newPos; //sets objects postion
        }
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
                    selected = hitInfo.transform;
                    position = hitInfo.transform.position;
                }
            }
            else
            {
                selected.transform.position = position;
                selected = null;
            }
        }
    }
}
