using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public bool isEnemyDestroyed;
    
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
        {
            Destroy(other);
            isEnemyDestroyed = true;
        }

    }
        public void ReduceSpeed(float reducedBy)
    {
        _moveSpeed /= reducedBy;
    }

}
