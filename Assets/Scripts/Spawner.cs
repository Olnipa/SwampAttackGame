using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _target;

    private Wave _currentWave;
    private int _currentWaveNumber = -1;
    private WaitForSeconds _spawnWait;
    private Coroutine _spawnCoroutine;
    private int _spawnedEnemyCount;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetNextWave();
        _spawnWait = new WaitForSeconds(_currentWave.Delay);
    }

    private Wave GetNextWave()
    {
        if (++_currentWaveNumber < _waves.Count)
        {
            return _waves[_currentWaveNumber];
        }

        return null;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Tamplate, _spawnPoint.position, Quaternion.identity, transform).GetComponent<Enemy>();
        enemy.Initialise(_target);
        enemy.Died += OnEnemyDied;
    }

    private IEnumerator SpawnEnemyJob()
    {
        if (_spawnCoroutine == null)
        {
            for (int i = 0; i < _currentWave.EnemyCount; i++)
            {
                InstantiateEnemy();
                _spawnedEnemyCount++;
                EnemyCountChanged?.Invoke(_spawnedEnemyCount, _currentWave.EnemyCount);
                yield return _spawnWait;
            }

            _spawnCoroutine = null;
            TryInitializeNextWave();
        }
    }

    private void TryInitializeNextWave()
    {
        if (_target.IsAlive && _currentWaveNumber + 1 < _waves.Count)
        {
            SetNextWave();
            AllEnemySpawned?.Invoke();
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        if (enemy.Reward > 0)
            _target.AddMoney(enemy.Reward);

        enemy.Died -= OnEnemyDied;
    }

    private void SetNextWave()
    {
        _currentWave = GetNextWave();
        _spawnCoroutine = null;
        _spawnedEnemyCount = 0;
        _spawnWait = new WaitForSeconds(_currentWave.Delay);
    }

    public void StartWave()
    {
        EnemyCountChanged?.Invoke(0, 1);
        _spawnCoroutine = StartCoroutine(SpawnEnemyJob());
    }
}