using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public event UnityAction EnemyKilled;

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
        if (other.GetComponent<EnemyMovement>() != null)
            DestroyEnemy(other);
    }
    public void ReduceSpeed(float reducedBy)
    {
        _moveSpeed /= reducedBy;
    }

    private void DestroyEnemy(GameObject enemy)
    {
        DestroyImmediate(enemy);
        if (EnemyKilled != null)
            EnemyKilled.Invoke();
    }

}
