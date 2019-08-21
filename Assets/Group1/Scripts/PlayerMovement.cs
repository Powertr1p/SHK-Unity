using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_moveSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
    }

    public void OnCollision(GameObject other)
    {
        if (other.GetComponent("EnemyMovement") as EnemyMovement != null)
            Debug.Log("Destroyed");
        
        //Закоментил, так как в сцене нет объекта
        /* if (entity.name == "Speed")
         {
             _moveSpeed *= 2;
             IsTimerOn = true;
             TimeRemain += 2;
         } */
    }
    public void ReduceSpeedTimer(float reducedBy)
    {
        _moveSpeed /= reducedBy;
    }

}
