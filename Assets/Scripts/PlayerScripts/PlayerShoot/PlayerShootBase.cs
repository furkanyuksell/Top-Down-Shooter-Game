using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShootBase : MonoBehaviour
{// On the other hand this class is Primary Gun Class
    bool _canFire = false; // su anda kullanılmıyor sadece eklenti
    [SerializeField] MovementBase _movementBase;
    [SerializeField] PlayerSecondaryGun playerSecondaryGun;
    Vector3 _fireDirection;
    Weapon _weapon;
    bool _canChangeWeapon = true;
    void Awake()
    {
        if (_weapon == null)
        {
            _weapon = GetComponentInChildren<Weapon>();
            SetGunTransform();
        }
    }

    void SetGunTransform()
    {
        _weapon.transform.position = this.transform.position;
        _weapon.transform.rotation = this.transform.rotation;
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
        if (!_movementBase.RunControl() && _weapon != null)
        {
            _weapon.WeaponShoot();   
        }
    }

    void InitializeWeapon(Weapon weapon)
    {
        _weapon = weapon;
        SetGunTransform();
    }

    void WeaponChange()
    {
        if (playerSecondaryGun.HasSecondGun() && _canChangeWeapon && !_movementBase.RunControl())
        {
            PlayerAnimBase.OnWeaponChangeAnim?.Invoke();
            EventManagement.FreezeGunSystem?.Invoke(false);
            _canChangeWeapon = false;
            StartCoroutine(IsWeaponChangeAnimReady(.8f));
        }
    }

    IEnumerator IsWeaponChangeAnimReady(float animTime)
    {
        yield return new WaitForSeconds(animTime);
        _weapon = playerSecondaryGun.GetSecondaryWeapon(_weapon);
        PlayerAnimBase.OnRigControllerTriggerAnim?.Invoke(_weapon.AnimName());
        InitializeWeapon(_weapon);
        _canChangeWeapon = true;
        EventManagement.FreezeGunSystem?.Invoke(true);
    }

    void OnEnable()
    {
        InputBase.OnMouseDown     += OnShootMouseDown;
        InputBase.OnMouseUp       += OnShootMouseUp;
        InputBase.OnMouseDrag     += OnShootMouseDrag;
        InputBase.OnWeaponChange  += WeaponChange;
    }
    void OnDisable()
    {
        InputBase.OnMouseDown     -= OnShootMouseDown;
        InputBase.OnMouseUp       -= OnShootMouseUp;
        InputBase.OnMouseDrag     -= OnShootMouseDrag;
        InputBase.OnWeaponChange  -= WeaponChange;
    }
}
