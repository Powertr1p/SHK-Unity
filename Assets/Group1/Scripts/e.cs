using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    private Vector3 target;
    private Vector3 currentPosition;

    [SerializeField] private float speed;
    [SerializeField] private int radius;

    // Start is called before the first frame update
    void Start()
    {
        GetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position = currentPosition;
        if (transform.position == target)
            GetTarget();
    }

    private void GetTarget()
    {
        target = Random.insideUnitCircle * radius;
    }
}
