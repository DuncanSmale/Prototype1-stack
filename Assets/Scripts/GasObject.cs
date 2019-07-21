using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasObject : MonoBehaviour
{

    float EnableTime = 0;

    private void Awake()
    {
        EnableTime = Time.time + 0.5f;
    }

    private void OnEnable()
    {
        if (Time.time > EnableTime && GasController.Controller.isIn(this) == false)
        {
            GasController.Controller.addGas(this);
        }
    }

    private void OnDisable()
    {
        if (GasController.Controller.isIn(this) == true)
        {
            GasController.Controller.removeGas(this);
        }
    }
}
