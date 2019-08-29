using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _collisionDistance = 0.2f;

    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private GameObject[] _enemies;

    private float _timeRemain;
    private bool _isTimerOn;

    private float _distance;

    private void Start()
    {
        _player.EnemyKilled += IsGameEnd;
    }

    private void Update()
    {
        TimerManagement();
        DetectCollision();
    }

    private void TimerManagement()
    {
        if (_isTimerOn)
        {
            _timeRemain -= Time.deltaTime;
            if (_timeRemain < 0)
            {
                _isTimerOn = false;
                _player.ReduceSpeed(0.2f);
            }
        }
    }

    private void DetectCollision()
    {
        foreach (var entity in _enemies)
        {
            if (entity != null)
            {
                _distance = Vector3.Distance(_player.gameObject.gameObject.GetComponent<Transform>().position, entity.gameObject.gameObject.transform.position);
                if (_distance < _collisionDistance)
                    _player.OnCollision(entity);
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
