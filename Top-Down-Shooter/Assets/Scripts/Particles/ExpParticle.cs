using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class ExpParticle : MonoBehaviour
{
    public ObjectPool<ExpParticle> _expPool;
    public void SetPool(ObjectPool<ExpParticle> pool) => _expPool = pool;
    
    
}
