using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerRigging : MonoBehaviour
{
    
    [SerializeField] Rig _runningLayer;
    [SerializeField] Transform weaponParent;
    [SerializeField] Transform weaponLeftGrip;
    [SerializeField] Transform weaponRightGrip;
    [SerializeField] Animator rigController;
    
    void SetRigRunning(bool state)
    {
        if (state)
        {
            _runningLayer.weight = 1f;
        }else
        {
            _runningLayer.weight = 0f;
        }
    }
    void OnWeaponChangeAnim()
    {
        if (rigController.GetCurrentAnimatorStateInfo(0).IsName("WeaponChange"))
            return;
        rigController.Play("WeaponChange");
    }
    void OnEnable()
    {
        PlayerAnimBase.OnWeaponChangeAnim += OnWeaponChangeAnim;
        EventManagement.OnRigRunning += SetRigRunning;
    }

    void OnDisable()
    {
        PlayerAnimBase.OnWeaponChangeAnim -= OnWeaponChangeAnim;        
        EventManagement.OnRigRunning -= SetRigRunning;
    }
}
