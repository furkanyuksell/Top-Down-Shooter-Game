using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EnemyBase : MonoBehaviour
{
    public ObjectPool<EnemyBase> _enemyPool;
    public void SetPool(ObjectPool<EnemyBase> enemyPool) => _enemyPool = enemyPool;


}
