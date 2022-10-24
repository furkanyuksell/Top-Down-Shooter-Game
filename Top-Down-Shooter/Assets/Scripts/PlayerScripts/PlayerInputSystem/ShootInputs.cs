using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInputs : InputBase
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire");
        }
        else if (Input.GetMouseButton(0))
        {
            Debug.Log("FireGoesOn");
        }else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("EndFire");
        }
    }
}
