using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 currentPosition;

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private int radius = 4;

    // Start is called before the first frame update
    void Start()
    {
        NextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position = currentPosition;
        if (transform.position == target)
            NextTarget();
    }

    private void NextTarget()
    {
        target = Random.insideUnitCircle * radius;
    }
}
