using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun Data", order = 0)]
public class WeaponData : ScriptableObject {
    public Projectile projectile;
    public int damage = 5;
    public float fireRate = 0.5f;
    public float range = 10;    
    public string animName;
}