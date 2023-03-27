using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerSecondaryGun : MonoBehaviour
{
    Weapon _primaryGun;
    Weapon _secondaryGun;
    
    public void SetSecondryGun(Weapon secondweapon)
    {
        _secondaryGun = secondweapon;
        SetSecondaryGunTransform();
    }

    public bool HasSecondGun()
    {
        if (_secondaryGun == null)
            return false;
        else
            return true; 
    }

    public Weapon GetSecondaryWeapon(Weapon primaryGun)
    {
        _secondaryGun.transform.parent = primaryGun.transform.parent.transform;
        primaryGun.transform.parent = this.transform;

        _primaryGun = _secondaryGun;
        _secondaryGun = primaryGun;

        SetSecondaryGunTransform();   

        return _primaryGun;
    }

    void SetSecondaryGunTransform()
    {
        _secondaryGun.transform.position = this.transform.position;
        _secondaryGun.transform.rotation = this.transform.rotation;   
    }

    void WeaponDropped()
    {
        if (HasSecondGun())
        {
            Destroy(_secondaryGun.gameObject);   
        }
    }

    void OnEnable()
    {
        InputBase.OnWeaponDrop += WeaponDropped;
    }

    void OnDisable()
    {
        InputBase.OnWeaponDrop -= WeaponDropped;
    }
}
