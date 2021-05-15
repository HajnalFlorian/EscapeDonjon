using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiIA : MonoBehaviour
{
    public float Speed;
    private float stopDistance = 1f;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stopDistance)
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }
}
