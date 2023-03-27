using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerAnimBase : MonoBehaviour
{
    public static Action OnWeaponChangeAnim;
    public static Action<string> OnRigControllerTriggerAnim;
}
