using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Transform startPosition;

    private void Start()
    {

    }

    void Update()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);

        if (transform.position == targetPosition.position)
        {
            targetPosition.position = startPosition.position;
            
        }
        
    }
}
