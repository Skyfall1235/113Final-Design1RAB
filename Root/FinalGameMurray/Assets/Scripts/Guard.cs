using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guard: MonoBehaviour
{
    public GameObject targetA;
    public GameObject targetB;
    public float speed = 2f;
    private Transform currentTarget;


    // Start is called before the first frame update
    void Start()
    {
        currentTarget = targetA.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == targetA.transform ? targetB.transform : targetA.transform;
        }
    }

    
}
