using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : Singleton<ProjectilePool>
{
    public ObjectPool<Projectile> projectilePool;
    Projectile _projectile;
    protected override void Awake()
    {
        base.Awake();
        projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnTakeProjectileFromPool, OnReturnProjectileToPool);
    } 

    public void InitProjectile(Projectile projectile)
    {
        _projectile = projectile;
    }

    Projectile CreateProjectile()
    {
        var projectile = Instantiate(_projectile);
        projectile.gameObject.transform.parent = this.gameObject.transform;
        projectile.SetPool(projectilePool);
        return projectile;
    }

    void OnTakeProjectileFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    void OnReturnProjectileToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
}
