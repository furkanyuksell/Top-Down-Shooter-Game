using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] Transform _playerTransform;
    [SerializeField] EnemyAnim enemyAnim;

    Rigidbody m_Rigidbody;
    Vector3 _distanceVector;
    Vector3 _moveDirection;
    float _gb;

    bool _waitForASecond;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _gb = 255;
    }

    private void FixedUpdate()
    {
        _gb -= Time.deltaTime * 100;
        SendIt();
    }

    private void SendIt()
    {
        _distanceVector = _playerTransform.position - transform.position;
        _moveDirection.x = _distanceVector.x;
        _moveDirection.z = _distanceVector.z;
        transform.forward = _moveDirection;
        _distanceVector = (_playerTransform.position - transform.position);
        if (_gb <= 0)
        {
            enemyAnim.AnimTrigger("Attack");
            m_Rigidbody.AddForce(transform.forward * 750);
            _gb = 255f;
            StartCoroutine(StopTheEnemy());
        }
    }

    private IEnumerator StopTheEnemy()
    {
        yield return new WaitForSeconds(1f);
        m_Rigidbody.angularVelocity = Vector3.zero;
        m_Rigidbody.velocity = Vector3.zero;
    }   
}
