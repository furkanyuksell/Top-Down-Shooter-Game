using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
    [SerializeField] int _health = 1;

    public void Damage(int damage)
    {
        _health -= damage;
    }
}
