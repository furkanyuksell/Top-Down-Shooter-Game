using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] LayerMask _aimLayerMask;

    Vector3 movement;
    Vector3 _direction;
    Vector3 _mousePos;
    float _changeRunSpeed=1;
    float _changeWalkSpeed=1;
    bool _isRun = false;            
    bool _canMove = false;
    
    void Update()
    {
        AimTowardMouse();
        if (_isRun)
        {
            RunMovement();
        }else
        {
            if(_canMove)
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
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime * _changeWalkSpeed;
            transform.Translate(movement, Space.World);
        }   
    }

    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePos);
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
    
    private void CanMove(bool state)
    {
        _canMove = state;
    }

    private void OnMoveBasePressed()
    {
        CanMove(true);
    }
    private void OnMoveBaseReleased()
    {
        movement = new Vector3(0f, 0f, 0f);
        CanMove(false);
    }
    private void OnMoveBaseInput(Vector3 newDirection)
    {
        movement = newDirection;
    }

    private void OnRunBasePressed()
    {
        _isRun = true;
    }
    private void OnRunBaseReleased()
    {
        _isRun = false;
    }

    private void OnMouseBasePosition(Vector3 getMousePos)
    {
        _mousePos = getMousePos;
    }

    void OnEnable()
    {
        InputBase.OnMovePressed += OnMoveBasePressed;
        InputBase.OnMoveReleased += OnMoveBaseReleased;
        InputBase.OnMoveInput += OnMoveBaseInput;
        InputBase.OnRunPressed += OnRunBasePressed;
        InputBase.OnRunReleased += OnRunBaseReleased;
        InputBase.OnMousePosition += OnMouseBasePosition;
    }

    void OnDisable()
    {
        InputBase.OnMovePressed -= OnMoveBasePressed;
        InputBase.OnMoveReleased -= OnMoveBaseReleased;
        InputBase.OnMoveInput -= OnMoveBaseInput;
        InputBase.OnRunPressed -= OnRunBasePressed;
        InputBase.OnRunReleased -= OnRunBaseReleased;
        InputBase.OnMousePosition -= OnMouseBasePosition;

    }
}
