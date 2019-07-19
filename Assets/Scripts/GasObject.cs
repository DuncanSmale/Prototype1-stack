using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasObject : MonoBehaviour
{

    private void OnEnable()
    {
        if (Time.time > 0.5f && GasController.Controller.isIn(this) == false)
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
