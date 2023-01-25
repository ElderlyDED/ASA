using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WorldTimer _timerScript;
    [SerializeField] List<GameObject> _oneTierEnemy = new();
    [SerializeField] List<GameObject> _twoTierEnemy = new();
    [SerializeField] List<GameObject> _threeTierEnemy = new();
    [SerializeField] List<GameObject> _spawnPointsEnemy = new();
    [SerializeField] bool _readyOneTier;
    [SerializeField] bool _readyTwoTier;
    [SerializeField] bool _readyThreeTier;
    [SerializeField] int _timeOneTier;
    [SerializeField] int _timerTwoTier;
    [SerializeField] int _timerThreeTier;
    [SerializeField] int _amountOneTierEnemy;
    [SerializeField] int _amountTwoTierEnemy;
    [SerializeField] int _amountThreeTierEnemy;
    [SerializeField] int _nextSpawnTimeEnemy;
    [field: SerializeField] public int Wave;
    void Start()
    {
        _timerScript = gameObject.GetComponent<WorldTimer>();
        _spawnPointsEnemy.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointEnemy"));
    }
    void Update()
    {
        CheckReadyTier();
        SpawnEnemy();
    }

    void CheckReadyTier() 
    {
        if (_timeOneTier == _timerScript.Time)
        {
            _readyOneTier = true;
        }
        if (_timerTwoTier == _timerScript.Time)
        {
            _readyTwoTier = true;
        }
        if (_timerThreeTier == _timerScript.Time)
        {
            _readyThreeTier = true;
        }
    }

    void SpawnEnemy()
    {
        if (_readyOneTier == true && _readyTwoTier == false && _readyThreeTier == false && _nextSpawnTimeEnemy == _timerScript.Time)
        {
            Wave += 1;
            _nextSpawnTimeEnemy += 60;
            EnemySpawnCycle(_oneTierEnemy, _amountOneTierEnemy);
        }
        else if (_readyOneTier == true && _readyTwoTier == true && _readyThreeTier == false && _nextSpawnTimeEnemy == _timerScript.Time)
        {
            Wave += 1;
            _nextSpawnTimeEnemy += 60;
            EnemySpawnCycle(_oneTierEnemy, _amountOneTierEnemy);
            EnemySpawnCycle(_twoTierEnemy, _amountTwoTierEnemy);
        }
        else if (_readyOneTier == true && _readyTwoTier == true && _readyThreeTier == true && _nextSpawnTimeEnemy == _timerScript.Time)
        {
            Wave += 1;
            _nextSpawnTimeEnemy += 60;
            EnemySpawnCycle(_oneTierEnemy, _amountOneTierEnemy);
            EnemySpawnCycle(_twoTierEnemy, _amountTwoTierEnemy);
            EnemySpawnCycle(_threeTierEnemy, _amountThreeTierEnemy);
        }
    }

    void EnemySpawnCycle(List<GameObject> _enemyList, int _amountEnemy)
    {
        for (int i = 0; i < _amountEnemy; i++)
        {
            int _randEnemy = Random.Range(0, _enemyList.Count);
            int _randSpawnPoint = Random.Range(0, _spawnPointsEnemy.Count);
            StartCoroutine(DelaySpawningEnemy(_enemyList[_randEnemy].gameObject, _spawnPointsEnemy[_randSpawnPoint].gameObject));
        }
    }

    IEnumerator DelaySpawningEnemy(GameObject _randEnemy, GameObject _randPoint)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject spawningEnemy = Instantiate(_randEnemy);
        spawningEnemy.transform.position = _randPoint.transform.position;

    }
}
