using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPackages.Scripts.Behaviour;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private List<Transform> _enemySpawnPoints;
    [SerializeField] private List<EnemyBase> _spawnEnemies;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private WallBehaviour _wallBehaviour;

    private List<int> _enemyCountOfLines;
    private int _nextEnemyType = 0;
    private EnemyBase _enemyBase;
    private string _spawnEnemyCoroutine = "SpawnEnemy";
    private bool _finishSpawnCoroutine = false;
    void Start()
    {
        StartCoroutine(_spawnEnemyCoroutine);
        _enemyCountOfLines = new List<int>() { 0, 0, 0 };
        LevelBehaviour.OnComplete += GameEnd;
    }
    private void GameEnd(bool v=false)
    {
        if (!_finishSpawnCoroutine)
            StopCoroutine(_spawnEnemyCoroutine);
    }
    private int GetSPawnLineIndex()
    {
        int min = 999, index = 0;
        int i = 0;
        _enemyCountOfLines.ForEach(s =>
        {
            if (s < min)
            {
                min = s;
                index = i;
            }
            i++;
        });
        _enemyCountOfLines[index]++;
        return index;
    }
    public void KillEnemy(int index)
    {
        _enemyCountOfLines[index]--;
    }
    private EnemyBase GetNextEnemy()
    {
        _nextEnemyType++;
        _nextEnemyType = _nextEnemyType == _spawnEnemies.Count ? 0 : _nextEnemyType;
        Debug.Log(_spawnEnemies.Count);
        return _spawnEnemies[_nextEnemyType];
    }

    private void OnDisable()
    {
        GameEnd();
    }
    IEnumerator SpawnEnemy()
    {
        do
        {
            yield return new WaitForSeconds(_spawnTime);
            int index = GetSPawnLineIndex();
            _enemyBase = Instantiate(GetNextEnemy(), _enemySpawnPoints[index].position, Quaternion.identity, transform);
            _enemyBase.SetData(_wallBehaviour, index);
            _maxEnemyCount--;
        }
        while (_maxEnemyCount > 0);
        _finishSpawnCoroutine = true;
    }
}
