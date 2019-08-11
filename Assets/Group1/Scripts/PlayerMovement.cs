using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    public void OnCollision(GameObject obj)
    {
        if (obj.name == "enemy")
            Destroy(obj);

        if (obj.name == "speed")
        {
            moveSpeed *= 2;
            isTimerOn = true;
            timeRemain += 2;
        }
    }
    public void ReduceSpeedFromTimer(float reducedBy)
    {
        moveSpeed /= reducedBy;
    }

}
