using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeableGun : MonoBehaviour
{
    [SerializeField] float _rotatingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, _rotatingSpeed, 0f) * Time.deltaTime);
    }
}
