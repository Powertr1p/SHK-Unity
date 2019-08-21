using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameController _gameController;
    
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

    public void OnCollision(GameObject entity)
    {
        if (entity.name == "enemy")
            Destroy(entity);

        if (entity.name == "Speed")
        {
            _moveSpeed *= 2;
            _gameController.IsTimerOn = true;
            _gameController.TimeRemain += 2;
        }
    }
    public void ReduceSpeedTimer(float reducedBy)
    {
        _moveSpeed /= reducedBy;
    }

}
