using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using DG.Tweening;
public class Grenade : MonoBehaviour
{
    [SerializeField] int _damage=10;
    [SerializeField] ParticleSystem _particle;
    [SerializeField] AudioSource _audio;
    [SerializeField] GameObject _tntArt;
    [SerializeField] SphereCollider _collider;
    bool _hitDamage = false;
    public ObjectPool<Grenade> _pool;
    public void SetPool(ObjectPool<Grenade> pool) => _pool = pool;
    public void Explosion(Vector3 _pos)
    {
        int randX = Random.Range(-10,10);
        int randZ = Random.Range(-10,10);
        _pos.y = .5f;
        transform.DOJump(_pos + new Vector3(randX, 0f, randZ), 1, 2, 1, false)
            .OnComplete(()=> PlayParticleSystem());
        DOVirtual.DelayedCall(1.5f, ()=> _pool.Release(this)).OnComplete(()=> ResetGrenade());
    }
    void ResetGrenade()
    {
        _tntArt.SetActive(true);
        _collider.enabled = false;
    }

    void PlayParticleSystem()
    {
        _tntArt.SetActive(false);
         _particle.Play();
        _audio.Play();
        _collider.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCombat>(out EnemyCombat enemyCombat))
        {
            IDamageable damageable = enemyCombat.GetComponent<IDamageable>();
            damageable.Damage(_damage);
        }
    }
}
