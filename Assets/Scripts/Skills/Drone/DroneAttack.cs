using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    Vector3 _enemyPos;
    [SerializeField] float lookAtSpeed=1;
    [SerializeField] Projectile projectile;
    [SerializeField] int _damage = 5;
    [SerializeField] float _rate;
    [SerializeField] Shooter[] shooters;    
    float _fireRateCounter = 0f;
    bool _canFire = true;
    private void Awake() 
    {
        //shooters = GetComponentsInChildren<Shooter>();
        foreach (var shooter in shooters)
        {
            if (shooter.gameObject.activeInHierarchy)
            {
                shooter.InitShooter(projectile, _damage, 10);   
            }
        }
    }
    void Update()
    {
        Vector3 targetDir = _enemyPos - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), lookAtSpeed);
        
        if(!_canFire)
            _fireRateCounter += Time.deltaTime;

        if (_fireRateCounter >= _rate)
        {
            _canFire = true;
            _fireRateCounter = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<EnemyCombat>(out EnemyCombat enemyCombat))
        {
            _enemyPos = enemyCombat.transform.position;    
            if (_canFire)
            {
                foreach (var shooter in shooters)
                    shooter.Shoot();
                _canFire = false;
            }
        }

        if (other.TryGetComponent<Enemy2Movement>(out Enemy2Movement enemy2Movement))
        {
            _enemyPos = enemy2Movement.transform.position;
            if (_canFire)
            {
                foreach (var shooter in shooters)
                    shooter.Shoot();
                _canFire = false;
            }
        }
    }

    public void ActivateShooter()
    {
        foreach (var shooter in shooters)
        {
            if (!shooter.gameObject.activeInHierarchy)
            {
                Debug.Log("inactive shooter"+ shooter.gameObject.name);
                shooter.gameObject.SetActive(true);
                shooter.InitShooter(projectile, _damage, 10);  
                return;
            }
        }
    }
}
