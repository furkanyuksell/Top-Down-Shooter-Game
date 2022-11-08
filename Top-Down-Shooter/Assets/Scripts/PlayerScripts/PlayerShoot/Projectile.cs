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
    float _oldPosZ;
    public void Setup(float range)
    {
        _rb.velocity = Vector3.zero;
        _range = range;
        _oldPosZ = transform.position.z;   
    }

    void FixedUpdate()
    {
        if ((transform.position.z - _oldPosZ) >= _range)
        {
            _pool.Release(this);
        }
    }

    public void ProjectileForce()
    {
        _rb.AddForce(transform.forward*10, ForceMode.Impulse);
    }
}