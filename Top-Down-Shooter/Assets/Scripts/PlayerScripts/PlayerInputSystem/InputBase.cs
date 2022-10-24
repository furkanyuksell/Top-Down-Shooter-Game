using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBase : MonoBehaviour
{
    public Vector3 MoveInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");      
        return  new Vector3(horizontal, 0f, vertical);;
    }

    public Ray MousePosition(){
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
