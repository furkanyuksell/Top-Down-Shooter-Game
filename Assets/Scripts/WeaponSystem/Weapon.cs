using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData _weaponData;
    [SerializeField] ParticleSystem _shootParticle;
    [SerializeField] AudioSource _shootSource;
    Shooter[] shooters;    
    float _fireRateCounter = 0f;
    bool _canFire = true;
    void Awake() 
    {        
        shooters = GetComponentsInChildren<Shooter>();
        
        if (shooters.Length == 0)
        {
            Debug.Log("Shooter Scripts Not Added in WeaponTip");
            return;
        }

        foreach (var shooter in shooters)
        {
            shooter.InitShooter(_weaponData.projectile, _weaponData.damage, _weaponData.range);
        }
    }
    public string AnimName(){
        return _weaponData.animName;
    }

    void Start()
    {
        WeaponBase.OnInitProjectile?.Invoke();   
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
                ShootEffects();
                shooter.Shoot();
            }   
            _canFire = false;
        }
    }

    void ShootEffects()
    {
        _shootParticle.Play();
        _shootSource.Play();
    }

    public void OnInitProjectile()
    {
        ProjectilePool.Instance.InitProjectile(_weaponData.projectile);
    }

    void OnEnable()
    {
        WeaponBase.OnInitProjectile += OnInitProjectile;
    }

    void OnDisable()
    {
        WeaponBase.OnInitProjectile -= OnInitProjectile;
    }

}
