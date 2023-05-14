using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private PlayerMoney _playerMoney;
    private PlayerHealth _playerHealth;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _killed;
    private int _AllEnemy;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyDying; 

    private void OnValidate()
    {
        if (_spawnPoint == null)
        {
            _spawnPoint = transform;
        }
    }

    private void Start()
    {
        _playerMoney = _player.gameObject.GetComponent<PlayerMoney>();
        _playerHealth = _player.gameObject.GetComponent<PlayerHealth>();

        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned.Invoke();
            }

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position,
                                    _spawnPoint.rotation, _spawnPoint)
                                    .GetComponent<Enemy>();

        enemy.Init(_playerHealth);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _killed = 0;
        _AllEnemy = _currentWave.Count;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _killed++;
        EnemyDying?.Invoke(_killed, _AllEnemy);

        _playerMoney.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}