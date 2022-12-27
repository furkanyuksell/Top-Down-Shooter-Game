using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : Singleton<GameLevel>
{
    [SerializeField] int _playerLevel = 1;
    [SerializeField] List<GameObject> spawnGate = new List<GameObject>();
    [SerializeField] GameObject _parent;
    Vector3 _playerPos;

    void SpawnGateWithLevelRate(int level)
    {
        _playerLevel = level;
        for (int i = 0; i < _playerLevel; i++)
        {
            Instantiate(spawnGate[Random.Range(0,2)], new Vector3(_playerPos.x+(Random.Range(-40,40)+_playerLevel), 0f, _playerPos.z+(Random.Range(-40,40)+_playerLevel)), Quaternion.identity, _parent.transform);   
        }
    }

    void PlayerPosition(Vector3 pos)
    {
        _playerPos = pos;
    }
    
    private void OnEnable()
    {
        EventManagement.OnPlayerLevel += SpawnGateWithLevelRate;
        EventManagement.PlayerPosition += PlayerPosition;
    }

    private void OnDisable()
    {
        EventManagement.OnPlayerLevel -= SpawnGateWithLevelRate;
        EventManagement.PlayerPosition -= PlayerPosition;
    }
}
