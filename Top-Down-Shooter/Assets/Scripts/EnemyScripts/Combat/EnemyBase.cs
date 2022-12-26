using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Pool;
public class EnemyBase : MonoBehaviour
{
    public static Action OnEnemyReset; 
    public ObjectPool<EnemyBase> _enemyPool;
    public void SetPool(ObjectPool<EnemyBase> enemyPool) => _enemyPool = enemyPool;
    public int enemyCount = 2;

    public void EnemyCount()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            _enemyPool.Clear();
            Destroy(gameObject,.5f);
        }
    }    

    public void EnemyRes(){
        OnEnemyReset?.Invoke();
    }
    
    public void ReleaseEnemy()
    {
        if (_enemyPool != null)
        {
            _enemyPool.Release(this);   
        }
    }

}
