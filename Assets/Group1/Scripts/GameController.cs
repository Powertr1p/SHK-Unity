using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _collisionDistance = 0.2f;

    [SerializeField] private GameObject _gameOverScreen;
    private PlayerMovement _player;
    private EnemyMovement[] _enemies;

    private float _timeRemain;
    private float _distance;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _enemies = FindObjectsOfType<EnemyMovement>();

        _player.EnemyKilled += IsGameEnd;
        _player.EnemyKilled += ResetTimer;
        ResetTimer();
    }

    private void Update()
    {
        ManageTimer();
        DetectCollision();
    }

    private void ManageTimer()
    {
        if (_timeRemain > 0)
            _timeRemain -= Time.deltaTime;
        else
        { 
            _player.ReduceSpeed(1.5f);
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        _timeRemain = 10f;
    }

    private void DetectCollision()
    {
        foreach (var entity in _enemies)
        {
            if (entity != null)
            {
                _distance = Vector3.Distance(_player.gameObject.gameObject.GetComponent<Transform>().position, entity.gameObject.gameObject.transform.position);
                if (_distance < _collisionDistance)
                    _player.OnCollision(entity.gameObject);
            }
        }
    } 

    private void IsGameEnd()
    {
        Component[] result = GameObject.FindObjectsOfType<EnemyMovement>();
        if (result.Length == 0)
            _gameOverScreen.SetActive(true);
    }
}
