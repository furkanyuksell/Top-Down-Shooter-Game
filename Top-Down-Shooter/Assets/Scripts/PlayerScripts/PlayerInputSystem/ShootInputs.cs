using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInputs : InputBase
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown?.Invoke();
        }
        else if (Input.GetMouseButton(0))
        {
            OnMouseDrag?.Invoke(Input.mousePosition);
        }else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp?.Invoke();
        }
    }
}
