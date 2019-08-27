using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _collisionDistance = 0.2f;

    public GameObject MenuScreen;
    public PlayerMovement Player;
    public GameObject[] Enemies;

    private float _timeRemain;
    private bool _isTimerOn;

    private float _distance;

    private void Start()
    {
        Player.EnemyKilled += IsGameEnd;
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
                Player.ReduceSpeed(0.2f);
            }
        }
    }

    private void DetectCollision()
    {
        foreach (var entity in Enemies)
        {
            if (entity != null)
            {
                _distance = Vector3.Distance(Player.gameObject.gameObject.GetComponent<Transform>().position, entity.gameObject.gameObject.transform.position);
                if (_distance < _collisionDistance)
                    Player.OnCollision(entity);
            }
        }
    } 

    private void IsGameEnd()
    {
        Component[] result = GameObject.FindObjectsOfType<EnemyMovement>();
        if (result.Length == 0)
            MenuScreen.SetActive(true);
    }
}
