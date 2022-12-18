using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _minDistance;
    [SerializeField] Transform _playerTransform;

    Rigidbody m_Rigidbody;
    Vector3 _distanceVector;
    Vector3 _moveDirection;
    bool _waitForASecond;


    private void Awake()
    {
        _playerTransform = FindObjectOfType<MovementBase>().transform;
        _moveDirection = Vector3.zero;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        _distanceVector = (_playerTransform.position - transform.position);
        _moveDirection.x = _distanceVector.x;
        _moveDirection.z = _distanceVector.z;
        transform.forward = _moveDirection.normalized;
        if (!_waitForASecond && Mathf.Sqrt((_moveDirection.x * _moveDirection.x) + (_moveDirection.z * _moveDirection.z)) > _minDistance)
        {
            m_Rigidbody.MovePosition(transform.position + _moveDirection.normalized * _speed * Time.deltaTime);
        }
        else
            StartCoroutine(CheckForDistance());
    }

    private IEnumerator CheckForDistance()
    {
        _waitForASecond = true;
        yield return new WaitForSeconds(1f);
        _waitForASecond = false;
    }
}
