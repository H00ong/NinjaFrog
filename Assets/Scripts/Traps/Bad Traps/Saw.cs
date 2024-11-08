using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Saw : Trap
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform[] movePoints;

    int destinationPointIndex = 0;

    void Start()
    {
        transform.position = new Vector2(movePoints[0].position.x, movePoints[0].position.y);
    }

    void Update()
    {
        MoveToDestinationPoints();
    }

    void MoveToDestinationPoints()
    {
        if (Vector2.Distance(movePoints[destinationPointIndex].position, transform.position) < .1f) 
        {
            destinationPointIndex++;

            if(destinationPointIndex == movePoints.Length)
                destinationPointIndex = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, movePoints[destinationPointIndex].position, moveSpeed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
