using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    Projectile _projectile;
    float _damage;
    float _range;
    public void InitShooter(Projectile projectile, float damage, float range)
    {
        _projectile = projectile;
        _damage = damage;
        _range = range;
    }
    
    public void Shoot()
    {
        var projectile = ProjectilePool.Instance.projectilePool.Get();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;         
        projectile.Setup(_range);
        projectile.ProjectileForce();
    }
}
