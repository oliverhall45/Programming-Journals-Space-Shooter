using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    [Space(15)]
    public float maxSpeed = 3f;
    public Vector3 playerPosition;
    public float accelerationTime = 2f;
    public float deaccelerationTime = -2f;
    public float timePassed = 0f;

    private Vector3 velocity = Vector3.zero;
    

    void Update()
    {
        PlayerMovement(); //constantly checks for button inputs in the method
    }

    public void PlayerMovement() //allows the player to move around with the arrow keys
    {
        float acceleration = maxSpeed / accelerationTime;
        float deacceleration = maxSpeed / deaccelerationTime;
        Vector3 inputDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputDirection += Vector3.right;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputDirection += Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputDirection += Vector3.down;
        }

        inputDirection.Normalize(); //keeps the player from moving twice as fast when going diagonal

        if(inputDirection != Vector3.zero)
        {
            velocity += inputDirection * acceleration * Time.deltaTime; //accelerates while one of the arrow keys is pressed
        }
        else
        {
            if(velocity.magnitude > 0f)
            {
                Vector3 deaccelVector = velocity.normalized * deacceleration * Time.deltaTime;

                if(deaccelVector.magnitude > velocity.magnitude)
                {
                    velocity = Vector3.zero; //stops moving so that the player doesn't go backwards when no inputs are pressed
                }
                else
                {
                    velocity -= deaccelVector; //deaccelerates when no input is pressed
                }
            }
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

       
        
    }

}