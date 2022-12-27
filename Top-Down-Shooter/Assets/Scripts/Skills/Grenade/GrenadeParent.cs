using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeParent : MonoBehaviour
{
    Vector3 _playerPos;
    [SerializeField] float _throwTime=1;
    [SerializeField] int _level = 1;

    void Awake()
    {
        StartCoroutine(GrenadeThrower());
    }
    public void UpgradeGrenade(){
        _level++;
        _throwTime-= 0.2f;
    }
    IEnumerator GrenadeThrower()
    {
        while(true)
        {
            yield return new WaitForSeconds(_throwTime);
            for (int i = 0; i < _level; i++)
            {
                var grenade = GrenadePool.Instance.grenadePool.Get();
                grenade.transform.position = _playerPos;
                grenade.Explosion(_playerPos);
            }
        }
    }

    void PlayerMoveVector(Vector3 direction)
    {
        _playerPos = direction;
        _playerPos.y = 3f;
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
