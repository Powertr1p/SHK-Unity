using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = Random.insideUnitCircle * 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
        if (transform.position == target)
            target = Random.insideUnitCircle * 4;
    }
}
