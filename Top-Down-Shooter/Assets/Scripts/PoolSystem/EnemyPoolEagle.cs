using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class EnemyPoolEagle : Singleton<EnemyPoolEagle>
{
    public ObjectPool<EnemyBase> enemyPool;
    [SerializeField] EnemyBase _enemy;

    protected override void Awake()
    {
        base.Awake();
        enemyPool = new ObjectPool<EnemyBase>(CreateEnemy, OnTakeParticleFromPool, OnReturnParticleToPool);
    }

    public void InitEnemy(EnemyBase enemyBase)
    {
        _enemy = enemyBase;
    }

    EnemyBase CreateEnemy()
    {
        var enemy = Instantiate(_enemy);
        enemy.gameObject.transform.parent = this.gameObject.transform;
        enemy.SetPool(enemyPool);
        return enemy;
    }
    void OnTakeParticleFromPool(EnemyBase enemyBase)
    {
        enemyBase.gameObject.SetActive(true);
    }

    void OnReturnParticleToPool(EnemyBase enemyBase)
    {
        enemyBase.gameObject.SetActive(false);
    }
}
