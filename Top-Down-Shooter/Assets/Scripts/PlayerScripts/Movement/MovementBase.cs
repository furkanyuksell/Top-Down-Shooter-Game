using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] LayerMask _aimLayerMask;

    Vector3 movement;
    Vector3 _direction;
    float _changeRunSpeed=1;
    float _changeWalkSpeed=1;
    bool _isRun = false;
    
    void Update()
    {
        AimTowardMouse();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunMovement();
        }else
        {
            WalkMovement();
        }
    }
    
    void RunMovement()
    {
            var runMove = _direction;
            runMove.Normalize();
            runMove *= _speed * Time.deltaTime * 2 * _changeRunSpeed;
            transform.Translate(runMove, Space.World);
            _isRun = true;
    }
    void WalkMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical);
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime * _changeWalkSpeed;
            transform.Translate(movement, Space.World);
        }   
        _isRun = false;
    }

    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _aimLayerMask))
        {
            _direction = hitInfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            transform.forward = _direction;
        }
    }

    public Vector3 MovementVector()
    {
        return movement;
    }

    public bool RunControl()
    {
        return _isRun;
    }

    //Call from another script this function to change movement speed
    public void ChangeRunSpeed(float speed)
    {
        _changeRunSpeed = speed;
    }
    public void ChangeWalkSpeed(float speed)
    {
        _changeWalkSpeed = speed;
    }
}
