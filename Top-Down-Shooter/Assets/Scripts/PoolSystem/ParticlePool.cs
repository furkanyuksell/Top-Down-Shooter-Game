using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ParticlePool : Singleton<ParticlePool>
{
    public ObjectPool<ExpParticle> expParticlePool;
    [SerializeField] ExpParticle _expParticle;
    protected override void Awake()
    {
        base.Awake();
        expParticlePool = new ObjectPool<ExpParticle>(CreateParticle, OnTakeParticleFromPool, OnReturnParticleToPool);
    }

    public void InitParticle(ExpParticle expParticle)
    {
        _expParticle = expParticle;
    }

    ExpParticle CreateParticle()
    {
        var expParticle = Instantiate(_expParticle);
        expParticle.gameObject.transform.parent = this.gameObject.transform;
        expParticle.SetPool(expParticlePool);
        return expParticle;
    }
    void OnTakeParticleFromPool(ExpParticle expParticle)
    {
        expParticle.gameObject.SetActive(true);
    }

    void OnReturnParticleToPool(ExpParticle expParticle)
    {
        expParticle.gameObject.SetActive(false);
    }
    
}
