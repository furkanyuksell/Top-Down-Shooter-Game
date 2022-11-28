using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action OnGameStart;
    protected override void Awake()
    {
        base.Awake();
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}
