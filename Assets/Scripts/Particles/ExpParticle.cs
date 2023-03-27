using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class ExpParticle : MonoBehaviour
{
    public ObjectPool<ExpParticle> _expPool;
    public void SetPool(ObjectPool<ExpParticle> pool) => _expPool = pool;
    
    int _experiance = 0;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            playerBase.Experiance(_experiance);
            _expPool.Release(this);
        }   
    }

    public void Experiance(int exp)
    {
        _experiance = exp;
    }
    
}
