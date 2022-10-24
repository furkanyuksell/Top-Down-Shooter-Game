using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _gunPow=5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Fire()
    {
        Debug.Log("Pistol proectile");    
    }
}
