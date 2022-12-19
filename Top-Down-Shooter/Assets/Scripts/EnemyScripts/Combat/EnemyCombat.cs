using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCombat : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] int _health = 2;
    [SerializeField] int _damage = 2;
    [SerializeField] float _attackSpeed=2f;
    float _attackTime=0;
    [SerializeField] GameObject[] children;
    [SerializeField] float[] offsets;
    [SerializeField] EnemyAnim enemyAnim;
    [SerializeField] Collider _enemyCollider;
    
    bool isAlive = true;


    private void FixedUpdate()
    {
        _attackTime += Time.deltaTime;
    }

    public void SplitIt()
    {
        if (children != null)
        {
            for(int i = 0; i < children.Length; i++)
            {
                children[i].transform.forward = transform.forward;
                children[i].transform.position = transform.position;
                children[i].SetActive(true);
                children[i].transform.DOMove(new Vector3(transform.position.x, 3f, transform.position.z) + transform.right / 2 * offsets[i], 0.4f).OnComplete(
                    ()=> children[i].transform.DOMove(new Vector3(transform.position.x, 1f, transform.position.z) + transform.right * offsets[i], 0.4f) );

                        
            }
        }
        gameObject.SetActive(false);
    }

    public void Damage(int damageTaken)
    {
        if (isAlive)
        {
            _health -= damageTaken;
            if (_health <= 0)
            {
                isAlive = false;
                enemyAnim.AnimTrigger("Die");
                var expParticle = ParticlePool.Instance.expParticlePool.Get();
                expParticle.transform.position = transform.position;
                StartCoroutine(WaitForSplitIt());
            }
            else
            {
                enemyAnim.AnimTrigger("GetHit");    
            }
        }
    }

    IEnumerator WaitForSplitIt()
    {
        yield return new WaitForSeconds(1f);
        SplitIt();
    }

    public void Kill()
    {
        _health = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_attackTime >= _attackSpeed)
        {
            if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
            {
                Debug.Log("Attack");
                enemyAnim.AnimTrigger("Attack");
                IDamageable damageable = playerBase.GetComponent<IDamageable>();
                damageable.Damage(_damage);
            }
            _attackTime = 0;
        }
    }
}
