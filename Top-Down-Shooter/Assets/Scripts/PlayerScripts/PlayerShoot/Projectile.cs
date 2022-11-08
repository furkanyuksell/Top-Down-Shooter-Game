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
    Vector3 _oldPos;

    public void Setup(float range)
    {
        _rb.velocity = Vector3.zero;
        _range = range;
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
            enemyCombat.SplitIt();
            _pool.Release(this);
        }
    }
}