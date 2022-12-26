using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EnemyBase : MonoBehaviour
{
    public ObjectPool<EnemyBase> _enemyPool;
    public void SetPool(ObjectPool<EnemyBase> enemyPool) => _enemyPool = enemyPool;
    public int enemyCount = 3;

    public void EnemyCount()
    {
        enemyCount--;
        if (enemyCount == 0)
            ReleaseEnemy();
    }
    
    public void ReleaseEnemy()
    {
        _enemyPool.Release(this);
    }

}
