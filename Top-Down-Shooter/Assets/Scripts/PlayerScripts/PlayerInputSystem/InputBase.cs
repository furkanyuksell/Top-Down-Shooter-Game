using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputBase : MonoBehaviour
{
    #region WalkMove
    public static Action OnMovePressed;
    public static Action OnMoveReleased;
    public static Action<Vector3> OnMoveInput;
    #endregion

    #region RunMove
    public static Action OnRunPressed;
    public static Action OnRunReleased;
    #endregion

    //Mouse Position for player rotation
    public static Action<Vector3> OnMousePosition;

    #region Shoot
    public static Action OnMouseDown;
    public static Action OnMouseUp;
    public static Action<Vector3> OnMouseDrag;
    #endregion

}
