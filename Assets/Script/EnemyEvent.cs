using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
    public float speed;

    private Transform target;

    void Start()
    {
        target = gameObject.FindGameObjectWithTag("Player ship").GetComponent<Transform>();
    }

    void Update()
    {
        if(vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime)
        }
    }
}
