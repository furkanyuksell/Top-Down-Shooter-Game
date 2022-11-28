using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public static Action<Weapon> OnWeaponChange;
    public static Action OnInitProjectile;
}
