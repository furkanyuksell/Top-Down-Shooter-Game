using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] int _health = 2;
    [SerializeField] int _damage = 2;
    [SerializeField] int _experiance = 2;

    [SerializeField] float _speed = 5f;
    [SerializeField] Transform _playerTransform;
    [SerializeField] EnemyAnim enemyAnim;
    [SerializeField] EnemyBase enemyBase;
    Rigidbody m_Rigidbody;
    Vector3 _distanceVector;
    Vector3 _moveDirection;
    float _gb;

    bool _waitForASecond;

    bool isAlive = true;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<MovementBase>().transform;
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

    public void Damage(int damageTaken)
    {
        Debug.Log("damageTaken");
        if (isAlive)
        {
            _health -= damageTaken;
            var popup = PopupPool.Instance.popupPool.Get();
            popup.transform.position = transform.position;
            popup.Setup(damageTaken);

            if (_health <= 0)
            {
                isAlive = false;
                enemyAnim.AnimTrigger("Die");

                var expParticle = ParticlePool.Instance.expParticlePool.Get();
                expParticle.transform.position = transform.position;
                expParticle.Experiance(_experiance);
                enemyBase.ReleaseEnemy();
                DOVirtual.DelayedCall(.3f,()=> enemyBase.ReleaseEnemy());
            }
            else
            {
                enemyAnim.AnimTrigger("GetHit");
            }
        }
    }

    public void Kill()
    {
        _health = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            IDamageable damageable = playerBase.GetComponent<IDamageable>();
            damageable.Damage(_damage);
        }
    }
}
