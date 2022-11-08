using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] GameObject[] children;
    [SerializeField] float[] offsets;


    public void SplitIt()
    {
        if (children != null)
        {
            for(int i = 0; i < children.Length; i++)
            {
                children[i].transform.forward = transform.forward;
                children[i].transform.position = transform.position;
                children[i].SetActive(true);
                children[i].transform.DOMove(new Vector3(transform.position.x, 3f, transform.position.z) + transform.right / 2 * offsets[i], 0.4f).OnComplete(
                    ()=> children[i].transform.DOMove(new Vector3(transform.position.x, 1f, transform.position.z) + transform.right * offsets[i], 0.4f) );

                        
            }
        }
        gameObject.SetActive(false);
    }
}