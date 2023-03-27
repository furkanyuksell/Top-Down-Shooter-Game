using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpTrigger : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerBase>(out PlayerBase playerBase))
        {
            transform.parent.DOMove(playerBase.transform.position, .5f);
        }   
    }   
}
