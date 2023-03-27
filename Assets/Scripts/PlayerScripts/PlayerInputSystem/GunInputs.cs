using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInputs : InputBase
{
    bool canUseGunSystem=true;
    void Update()
    {
        if (canUseGunSystem)
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
            
            if(Input.GetKeyDown(KeyCode.Q))
            {
                OnWeaponChange?.Invoke();
            }   
            if (Input.GetKeyDown(KeyCode.C))
            {
                OnWeaponDrop?.Invoke();
            }
            
        }else
        {
            OnMouseUp?.Invoke();
        }
    }

    void UseGunSystem(bool state)
    {
        canUseGunSystem = state;
    }
    void OnEnable()
    {
        EventManagement.FreezeGunSystem += UseGunSystem;
    }
    
    void OnDisable()
    {
        EventManagement.FreezeGunSystem -= UseGunSystem;
    }
}
