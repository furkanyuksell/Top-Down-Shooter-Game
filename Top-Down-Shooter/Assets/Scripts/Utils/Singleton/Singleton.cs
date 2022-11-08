using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : SingletonBase where T : Component
{
    public static T Instance { get; private set; } = null;

    protected override void Awake() 
    {
        if(Instance == null)
            Instance = this as T;
        else
            Destroy(gameObject);
    }
}
