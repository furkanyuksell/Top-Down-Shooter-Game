using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharper : MonoBehaviour
{
    [SerializeField] int _damage = 2;
    [SerializeField] float _rotateSpeed=1;
    void Update()
    {
        transform.Rotate(Vector3.up*_rotateSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCombat>(out EnemyCombat enemyCombat))
        {
            IDamageable damageable = enemyCombat.GetComponent<IDamageable>();
            damageable.Damage(_damage);
        }

        if (other.TryGetComponent<Enemy2Movement>(out Enemy2Movement enemy2Movement))
        {
            IDamageable damageable = enemy2Movement.GetComponent<IDamageable>();
            damageable.Damage(_damage);
        }
    }
}
