using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TakeableGun : MonoBehaviour
{
    [SerializeField] float _rotatingSpeed;
    [SerializeField] GameObject _gun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, _rotatingSpeed, 0f) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<PlayerSecondaryGun>())
        {
            if (!other.GetComponentInChildren<PlayerSecondaryGun>().HasSecondGun())
            {
                var newGun = Instantiate(_gun, other.GetComponentInChildren<PlayerSecondaryGun>().transform);
                other.GetComponentInChildren<PlayerSecondaryGun>().SetSecondryGun(newGun.GetComponentInChildren<Weapon>());
                Destroy(this.gameObject);   
            }
        }
    }
}
