using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject objectOne;
    public GameObject[] objArray;

    private float distance;
    [SerializeField] private float collisionDistance = 0.2f;

     // Update is called once per frame
    void Update()
    {
        foreach (var obj in objArray)
        {
            distance = Vector3.Distance(objectOne.gameObject.gameObject.GetComponent<Transform>().position, obj.gameObject.gameObject.transform.position);
            if (distance < collisionDistance)
                objectOne.SendMessage("Send Message", obj);
        }
    }

    public void GameEnd()
    {
        menuScreen.SetActive(true);
    }
}
