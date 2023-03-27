using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBox : MonoBehaviour
{
    [SerializeField] GameObject _drone;
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            var finded = GameObject.FindGameObjectWithTag("Drone");
            if (finded == null)
            {
                Instantiate(_drone);
            }else
            {
                finded.GetComponent<DroneAttack>().ActivateShooter();
            }

            Destroy(gameObject);
        }
    }
/*
    void GetDroneScript(GameObject drone, PlayerBase playerBase){
        foreach (var finded in playerBase.activeSkill)
        {
            if (finded == drone)
            {
                finded.GetComponent<DroneAttack>().ActivateShooter();        
            }
        }
    }

    void GetGrenadeScript(GameObject grenade, PlayerBase playerBase){
        foreach (var finded in playerBase.activeSkill)
        {
            if (finded == grenade)
            {
                finded.GetComponent<GrenadeParent>().UpgradeGrenade();    
            }
        }
    }

    void GetSharperScript(GameObject sharper, PlayerBase playerBase){
        foreach (var finded in playerBase.activeSkill)
        {
            if (finded == sharper)
            {
                finded.GetComponent<SharpReaper>().OpenNewSharper();   
            }
        }
    }*/
}
