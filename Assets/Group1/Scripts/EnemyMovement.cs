using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float frameSpeed = 2.0f;
    [SerializeField] private int radius = 4;
    private Vector3 currentPosition;
    private Vector3 target;

    void Start()
    {
        NextTarget();
    }

    void Update()
    {
        Moving();

        if (transform.position == target)
            NextTarget();
    }

    private void NextTarget()
    {
        target = Random.insideUnitCircle * radius;
    }

    private void Moving()
    {
        currentPosition = Vector3.MoveTowards(transform.position, target, frameSpeed * Time.deltaTime);
        transform.position = currentPosition;
    }
}
