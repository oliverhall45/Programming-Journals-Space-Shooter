using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    private Vector2 targetPoint;
    private bool hasTarget = false;

    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        Vector2 currentPosition = transform.position;

        
        if (!hasTarget || Vector2.Distance(currentPosition, targetPoint) <= arrivalDistance)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

            
            if (randomDirection == Vector2.zero)
            {
                randomDirection = Vector2.up; //makes sure it doesnt move zero distance
            }

            //sets a new target for the object to move towards
            targetPoint = currentPosition + randomDirection * maxFloatDistance;
            hasTarget = true;
        }

        //move toward target
        Vector2 direction = (targetPoint - currentPosition).normalized;
        Vector2 newPosition = currentPosition + direction * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}