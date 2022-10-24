using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputBase : MonoBehaviour
{
    public static Action OnMovePressed;
    public static Action OnMoveReleased;
    public static Action<Vector3> OnMoveInput;

    public static Action OnRunPressed;
    public static Action OnRunReleased;

    public static Action<Vector3> OnMousePosition;
}
