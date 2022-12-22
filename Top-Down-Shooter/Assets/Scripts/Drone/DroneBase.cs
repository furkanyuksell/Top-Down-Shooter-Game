using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBase : MonoBehaviour
{
    #region movement
    Vector3 _move;
    [SerializeField] float _speed;
    [SerializeField] float _dist;
    float _range;
    #endregion
    
    #region Rotate around tha player
    Vector3 _positionOffset;
    float _angle;
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float circleRadius = 1;
    #endregion
    
    void FixedUpdate()
    {
        DroneMovementWithRotation();
    }

    void DroneMovementWithRotation()
    {
        _range = Vector3.Distance(transform.position, _move);
        if (_range >= _dist)
            transform.position = Vector3.MoveTowards(transform.position, _move, _speed * Time.deltaTime);
        else{
            _positionOffset.Set(
                Mathf.Cos( _angle ) * circleRadius,
                0,
                Mathf.Sin( _angle ) * circleRadius
            );
            transform.position = _move + _positionOffset;
            _angle += Time.deltaTime * rotationSpeed;
        }
    }


    void PlayerMoveVector(Vector3 direction)
    {
        _move = direction;
        _move.y = 3f;
    }

    void OnEnable()
    {
        EventManagement.PlayerPosition += PlayerMoveVector;
    }
    void OnDisable()
    {
        EventManagement.PlayerPosition -= PlayerMoveVector;
    }
}
