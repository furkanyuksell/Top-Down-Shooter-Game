using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] EnemyBase _enemy;
    [SerializeField] float _spawnTime = 5;
    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            _enemy = EnemyPoolEagle.Instance.enemyPool.Get();
            _enemy.EnemyRes();
            _enemy.transform.position = transform.position;
        }
    }
}
