using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] EnemyBase _enemy;
    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _enemy = EnemyPoolEagle.Instance.enemyPool.Get();
            _enemy.EnemyRes();
            _enemy.transform.position = transform.position;
        }
    }
}
