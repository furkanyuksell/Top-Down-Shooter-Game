using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBox : MonoBehaviour
{
    [SerializeField] GameObject _grenade;
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            var finded = GameObject.FindGameObjectWithTag("Grenade");
            if (finded == null)
            {
                Instantiate(_grenade);
            }else
            {
                finded.GetComponent<GrenadeParent>().UpgradeGrenade();
            }

            Destroy(gameObject);
        }
    }
}
