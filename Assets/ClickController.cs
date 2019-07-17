using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{

    private Vector3 position; //position of the object that is clicked on
    private Transform selected = null; //object that was clicked on
    [SerializeField] private LayerMask layerMask; //layermask to change which layer the ray cast will be performed on

    void Start()
    {
        
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
            newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), 0);
            selected.position = newPos;
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
