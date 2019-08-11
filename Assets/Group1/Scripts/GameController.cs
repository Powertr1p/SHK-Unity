using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject objectOne;
    public GameObject[] objArray;

    private float distance;
    [SerializeField] private float collisionDistance;

     // Update is called once per frame
    void Update()
    {
        GameStatus();
    }

    public void GameStatus()
    {
        foreach (var obj in objArray)
        {
            distance = Vector3.Distance(objectOne.gameObject.gameObject.GetComponent<Transform>().position, 
                                                              obj.gameObject.gameObject.transform.position);
            if (obj != null)
            {
                if (distance < collisionDistance)
                {
                    objectOne.SendMessage("You are dead", obj);
                    GameEnd();
                }
            }
        }
    }

    public void GameEnd()
    {
        menuScreen.SetActive(true);
    }
}
