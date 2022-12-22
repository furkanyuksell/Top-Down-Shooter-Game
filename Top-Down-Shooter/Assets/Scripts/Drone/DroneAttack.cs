using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    Vector3 _enemyPos;
    [SerializeField] float lookAtSpeed=1;

    void FixedUpdate()
    {
        //transform.LookAt(_enemyPos*Time.deltaTime*lookAtSpeed);    
    }

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<EnemyBase>(out EnemyBase enemyBase))
        {
            _enemyPos = enemyBase.transform.position;
        }
    }

}
