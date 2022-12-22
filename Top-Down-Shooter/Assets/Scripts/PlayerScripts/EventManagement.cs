using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManagement : MonoBehaviour
{
    public static Action<bool> FreezeGunSystem;
    public static Action<bool> FreezeMoveSystem;
    public static Action<Vector3> PlayerPosition;
    public static Action<bool> OnRigRunning;
}
