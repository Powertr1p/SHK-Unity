using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _collisionDistance = 0.2f;

    public GameObject MenuScreen;
    public PlayerMovement Player;
    public GameObject[] Enemies;

    public float TimeRemain;
    public bool IsTimerOn;

    private float _distance;

    private void Update()
    {
        TimerManagement();
        DetectCollision();
        IsGameEnd();
    }

    public void TimerManagement()
    {
        if (IsTimerOn)
        {
            TimeRemain -= Time.deltaTime;
            if (TimeRemain < 0)
            {
                IsTimerOn = false;
                Player.ReduceSpeedFromTimer(0.2f);
            }
        }
    }

    public void DetectCollision()
    {
        foreach (var entity in Enemies)
        {
            _distance = Vector3.Distance(Player.gameObject.gameObject.GetComponent<Transform>().position, entity.gameObject.gameObject.transform.position);
            if (_distance < _collisionDistance)
                Player.OnCollision(entity); 
        }
    }

    public void IsGameEnd()
    {
        GameObject[] result = GameObject.FindGameObjectsWithTag("enemy");
        if (result.Length == 0)
            MenuScreen.SetActive(true);
    }
}

