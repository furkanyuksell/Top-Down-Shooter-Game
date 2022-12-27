using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpReaper : MonoBehaviour
{
    Vector3 _move;
    [SerializeField] float _rotateSpeed=5;
    [SerializeField] List<Sharper> sharpers;
    List<Sharper> activeSharpers = new List<Sharper>();
    [SerializeField] int count = 0;

    void Update()
    {
        transform.position = _move;
        transform.Rotate(transform.up, _rotateSpeed);
    }

    private void Awake()
    {
        GetInOrder();
    }

    void GetInOrder()
    {
        activeSharpers.Clear();
        count = 0;
        foreach (Sharper sharp in sharpers)
        {
            if (sharp.gameObject.activeInHierarchy)
            {
                count++;
                sharp.transform.localPosition = Vector3.up*2;
                sharp.transform.localRotation = Quaternion.identity;
                activeSharpers.Add(sharp);
            }
        }
        _rotateSpeed += count/5;
        
        float angleStep = 360 / count;

        for(int i = 0; i < count; i++)
        {
            activeSharpers[i].transform.RotateAround(transform.position,Vector3.up, angleStep*i);
            activeSharpers[i].transform.localPosition = activeSharpers[i].transform.forward*4;
        }
    }

    public void OpenNewSharper()
    {
        foreach(Sharper sharp in sharpers)
        {
            if (!sharp.gameObject.activeInHierarchy)
            {
                sharp.gameObject.SetActive(true);
                GetInOrder();
                return;
            }
        }
    }
    

    void PlayerMoveVector(Vector3 direction)
    {
        _move = direction;
        _move.y = 2f;
    }

    void OnEnable()
    {
        EventManagement.PlayerPosition += PlayerMoveVector;
    }
    void OnDisable()
    {
        EventManagement.PlayerPosition -= PlayerMoveVector;
    }
}
