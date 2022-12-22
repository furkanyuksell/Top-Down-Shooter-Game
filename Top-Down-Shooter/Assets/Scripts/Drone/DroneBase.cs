using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DroneBase : MonoBehaviour
{
    #region Rotate around tha player
    Vector3 _move;
    Vector3 _positionOffset;
    float _angle;
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float circleRadius = 1;
    #endregion
    
    void Update()
    {
        DroneMovementWithRotation();
    }

    void DroneMovementWithRotation()
    {
        _positionOffset.Set(
            Mathf.Cos( _angle ) * circleRadius,
            0,
            Mathf.Sin( _angle ) * circleRadius
            );
        transform.position = _move + _positionOffset;
        _angle += Time.deltaTime * rotationSpeed;       
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
