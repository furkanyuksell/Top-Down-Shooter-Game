using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class Projectile : MonoBehaviour
{
    public ObjectPool<Projectile> _pool;
    public void SetPool(ObjectPool<Projectile> pool) => _pool = pool;
    [SerializeField] Rigidbody _rb;
    float _range;
    int _damage;
    Vector3 _oldPos;

    public void Setup(float range, int damage)
    {
        _rb.velocity = Vector3.zero;
        _range = range;
        _damage = damage;
        _oldPos = transform.position;   
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _oldPos) >= _range)
        {
            _pool.Release(this);
        }
    }

    public void ProjectileForce()
    {
        _rb.AddForce(transform.forward*10, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCombat>(out EnemyCombat enemyCombat))
        {
            IDamageable damageable = enemyCombat.GetComponent<IDamageable>();
            damageable.Damage(_damage);
            _pool.Release(this);
        }
    }
}