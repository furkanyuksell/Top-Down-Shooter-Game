using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputs : InputBase
{
    float horizontal, vertical;
    bool canUseMovementSystem=true;

    private Vector3 UpdateMovePosition()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");      
        return  new Vector3(horizontal, 0f, vertical);
    }
    
    void Update()
    {
        if (canUseMovementSystem)
        {
            #region if(Walk)
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                OnMovePressed?.Invoke();
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                OnMoveInput?.Invoke(UpdateMovePosition());
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                OnMoveReleased?.Invoke();
            }
            #endregion

            #region if(Run)
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                OnRunPressed?.Invoke();
                EventManagement.OnRigRunning?.Invoke(true);
            }else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                OnRunReleased?.Invoke();
                EventManagement.OnRigRunning?.Invoke(false);
            }
            #endregion            
        }else
        {
            OnMoveReleased?.Invoke();
            OnRunReleased?.Invoke();
        }
        
        OnMousePosition?.Invoke(Input.mousePosition);
        
    }

    void UseMovementSystem(bool state)
    {   
        canUseMovementSystem = state;
    }

    void OnEnable()
    {
        EventManagement.FreezeMoveSystem += UseMovementSystem;
    }
    void OnDisable()
    {
        EventManagement.FreezeMoveSystem -= UseMovementSystem;
    }
}
