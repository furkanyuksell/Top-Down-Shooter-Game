using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GrenadePool : Singleton<GrenadePool>
{
    
    public ObjectPool<Grenade> grenadePool;
    [SerializeField] Grenade _grenade;
    protected override void Awake()
    {
        base.Awake();
        grenadePool = new ObjectPool<Grenade>(CreateGrenade, OnTakeGrenadeFromPool, OnReturnGrenadeToPool);
    } 

    Grenade CreateGrenade()
    {
        var grenade = Instantiate(_grenade);
        grenade.gameObject.transform.parent = this.gameObject.transform;
        grenade.SetPool(grenadePool);
        return grenade;
    }

    void OnTakeGrenadeFromPool(Grenade grenade)
    {
        grenade.gameObject.SetActive(true);
    }

    void OnReturnGrenadeToPool(Grenade grenade)
    {
        grenade.gameObject.SetActive(false);
    }
}
