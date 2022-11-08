using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData _weaponData;
    Shooter[] shooters;    
    float _fireRateCounter = 0f;
    bool _canFire = true;
    void Awake() 
    {        
        shooters = GetComponentsInChildren<Shooter>();
        foreach (var shooter in shooters)
        {
            shooter.InitShooter(_weaponData.projectile, _weaponData.damage, _weaponData.range);
        }   
    }

    void Start() 
    {
        ProjectilePool.Instance.InitProjectile(_weaponData.projectile);
    }

    void Update()
    {
        if(!_canFire)
            _fireRateCounter += Time.deltaTime;

        if (_fireRateCounter >= _weaponData.fireRate)
        {
            _canFire = true;
            _fireRateCounter = 0;
        }
    }

    public void WeaponShoot()
    {
        if (_canFire)
        {
            foreach (var shooter in shooters)
            {
                shooter.Shoot();
            }   
            _canFire = false;
        }
    }

}
