using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : Singleton<GameLevel>
{
    [SerializeField] int _playerLevel = 1;
    [SerializeField] List<GameObject> spawnGate = new List<GameObject>();
    [SerializeField] GameObject _parent;
    float posX = 450;
    float posZ = 450;
    Vector3 _playerPos;
    float _levelSpawnTime;



    void SpawnGateWithLevelRate(int level)
    {
        _playerLevel = level;
        Instantiate(spawnGate[Random.Range(0,2)], new Vector3(_playerPos.x+50, 0f, _playerPos.z+50), Quaternion.identity, _parent.transform);

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
