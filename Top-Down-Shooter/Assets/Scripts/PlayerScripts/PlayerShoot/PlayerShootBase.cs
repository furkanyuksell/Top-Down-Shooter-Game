using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShootBase : MonoBehaviour
{
    bool _canFire = false; // su anda kullanılmıyor sadece eklenti
    [SerializeField] MovementBase _movementBase;
    Vector3 _fireDirection;
    Weapon _weapon;
    void Awake()
    {
        if (_weapon == null)
        {
            _weapon = GetComponentInChildren<Weapon>();
        }
    }
    private void OnShootMouseDown()
    {
        _canFire = true;
    }

    private void OnShootMouseUp()
    {
        _canFire = false;
    }

    private void OnShootMouseDrag(Vector3 fireDirection)
    {
        //fireDirection Kalkabilir kullanılmıyor su anda
        _fireDirection = fireDirection;
        if (!_movementBase.RunControl())
        {
            _weapon.WeaponShoot();   
        }
    }

    void OnEnable()
    {
        InputBase.OnMouseDown += OnShootMouseDown;
        InputBase.OnMouseUp   += OnShootMouseUp;
        InputBase.OnMouseDrag += OnShootMouseDrag;
    }
    void OnDisable()
    {
        InputBase.OnMouseDown -= OnShootMouseDown;
        InputBase.OnMouseUp   -= OnShootMouseUp;
        InputBase.OnMouseDrag -= OnShootMouseDrag;
    }
}
