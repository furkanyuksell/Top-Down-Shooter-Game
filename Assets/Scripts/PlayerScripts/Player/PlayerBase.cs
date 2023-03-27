using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
    [SerializeField] int _health = 1;
    [Header("DEBUG")]
    [SerializeField] int _experience = 0;
    [SerializeField] int _level = 1;
    public List<GameObject> activeSkill = new List<GameObject>();

    private void Start()
    {
        EventManagement.OnPlayerLevel?.Invoke(_level);
        EventManagement.OnPlayerHealth?.Invoke(_health);
        EventManagement.OnPlayerExp?.Invoke(_experience);
    }

    public void Damage(int damage)
    {
        _health -= damage;
        EventManagement.OnPlayerHealth?.Invoke(_health);
    }

    public void Health(int health)
    { 
        _health += health;
        if (_health >= 100)
            _health = 100;
        EventManagement.OnPlayerHealth?.Invoke(_health);
    }

    public void Experiance(int exp){
        _experience += exp;
        if (_experience >= 100)
        {
            _level++;
            _experience = 0;
            EventManagement.OnPlayerLevel?.Invoke(_level);
        }
        EventManagement.OnPlayerExp?.Invoke(_experience);
    }
}
