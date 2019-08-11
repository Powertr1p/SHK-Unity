using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float collisionDistance = 0.2f;

    public GameObject menuScreen;
    public GameObject Player;
    public GameObject[] objArray;

    private float distance;
    public float timeRemain;
    public bool isTimerOn;

    void Update()
    {
        TimerManagement();
        DetectCollision();
        isGameEnd();
    }

    public void TimerManagement()
    {
        if (isTimerOn)
        {
            timeRemain -= Time.deltaTime;
            if (timeRemain < 0)
            {
                isTimerOn = false;
                Player.ReduceSpeedFromTimer(0.2f);
            }
        }
    }

    public void DetectCollision()
    {
        foreach (var obj in objArray)
        {
            distance = Vector3.Distance(Player.gameObject.gameObject.GetComponent<Transform>().position, obj.gameObject.gameObject.transform.position);
            if (distance < collisionDistance)
                Player.OnCollision("enemy", obj); 
        }
    }

    public void isGameEnd()
    {
        GameObject[] result = GameObject.FindGameObjectsWithTag("enemy");
        if (result.Length == 0)
            menuScreen.SetActive(true);
    }
}

