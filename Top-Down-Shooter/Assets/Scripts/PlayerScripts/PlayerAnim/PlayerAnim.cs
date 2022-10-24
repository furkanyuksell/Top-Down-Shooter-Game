using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public MovementBase _movementBase;
    Vector3 movement;
    Animator _animator;
    void Awake() => _animator = GetComponentInChildren<Animator>();

    void Update()
    {
        if (_movementBase.RunControl())
        {
            _animator.SetBool("Run", true);   
        }else
        {
            movement = _movementBase.MovementVector().normalized;
            float velocityZ = Vector3.Dot(movement, transform.forward);
            float velocityX = Vector3.Dot(movement, transform.right);

            _animator.SetBool("Run",false);
            _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
            _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
        }
    }
}
