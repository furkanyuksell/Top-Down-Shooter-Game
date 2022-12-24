using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
    [SerializeField] int _health = 1;
    [Header("DEBUG")]
    [SerializeField] int _experiance = 0;
    [SerializeField] int _level = 1;
    
    public void Damage(int damage)
    {
        _health -= damage;
    }

    public void Experiance(int exp){
        _experiance += exp;
        if (_experiance >= 100)
        {
            _level++;
            _experiance = 0;
        }
    }
}
