using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    [SerializeField] GameObject _Box;
    [SerializeField] ParticleSystem _boxParticle;
    [SerializeField] int _health;
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            playerBase.Health(_health);
            _Box.SetActive(false);
            _boxParticle.Play();
            Destroy(gameObject,0.7f);
        }
    }
}
