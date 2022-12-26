using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] EnemyBase _enemy;
    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1);
        EnemyPool.Instance.InitEnemy(_enemy);
        _enemy = EnemyPool.Instance.enemyPool.Get();
        _enemy.transform.position = transform.position;
    }
}
