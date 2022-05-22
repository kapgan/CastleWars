using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private List<Transform> _enemySpawnPoints;
    [SerializeField] private EnemyBase _spawnEnemy;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private WallBehaviour _wallBehaviour;

    private EnemyBase _enemyBase;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }



    IEnumerator SpawnEnemy()
    {
        do
        {
            yield return new WaitForSeconds(_spawnTime);
            _enemyBase = Instantiate(_spawnEnemy, _enemySpawnPoints[Random.Range(0,3)].position, Quaternion.identity,transform);
            _enemyBase.SetEnemyData(Color.red, 10, 5, 5, 5, _wallBehaviour);
            _maxEnemyCount--;
        }
        while (_maxEnemyCount > 0);
    }
}
