using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharperBox : MonoBehaviour
{
    [SerializeField] GameObject _sharper;
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            var finded = GameObject.FindGameObjectWithTag("Sharper");
            if (finded == null)
            {
                Instantiate(_sharper);
            }else
            {
                finded.GetComponent<SharpReaper>().OpenNewSharper();
            }

            Destroy(gameObject);
        }
    }
}
