using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerRigging : MonoBehaviour
{
    
    [SerializeField] Rig _runningLayer;
    
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
    void OnEnable()
    {
        EventManagement.OnRigRunning += SetRigRunning;
    }

    void OnDisable()
    {
        EventManagement.OnRigRunning -= SetRigRunning;
    }
}
