using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private int _radius = 4;
    private Vector3 _currentPosition;
    private Vector3 _target;

    private void Start()
    {
        NextTarget();
    }

    private void Update()
    {
        Moving();

        if (transform.position == _target)
            NextTarget();
    }

    private void NextTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Moving()
    {
        _currentPosition = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);
        transform.position = _currentPosition;
    }
}
