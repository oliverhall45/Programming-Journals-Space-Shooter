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

    [Header("Circle drawer properties")]
    public float radius = 1f;
    public int circlePoints = 8;

    public GameObject enemy;

    [Header("Powerups properties")]
    public int numberOfPowerups;
    public GameObject powerupPrefab;

    void Update()
    {
        PlayerMovement(); //constantly checks for button inputs in the method
        EnemyRadar(radius, circlePoints);

        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnPowerups(radius, numberOfPowerups);
        }
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

    public void EnemyRadar(float radius, int circlePoints)
    {
        float angleStep = 360f / circlePoints;
        float radians = angleStep * Mathf.Deg2Rad;

        bool enemyDetected = false;

        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < circlePoints; i++)
        {
            float adjustment = radians * i;
            Vector3 point = new Vector3(Mathf.Cos(radians + adjustment), Mathf.Sin(radians + adjustment)) * radius;

            points.Add(point);
        }

        Vector3 center = transform.position;


       
       float distanceToEnemy = Vector3.Distance(center, enemy.transform.position);
       if (distanceToEnemy <= radius)
       {
          enemyDetected = true;
       }
        

        if (enemyDetected == true)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                Debug.DrawLine(center + points[i], center + points[i + 1], Color.red);
                Debug.DrawLine(center + points[points.Count - 1], center + points[0], Color.red);
            }
        }
        else
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                Debug.DrawLine(center + points[i], center + points[i + 1], Color.green);
                Debug.DrawLine(center + points[points.Count - 1], center + points[0], Color.green);
            }
        }
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float angleStep = 360f / numberOfPowerups;
        float radians = angleStep * Mathf.Deg2Rad;

       
        
        for (int i = 0; i < numberOfPowerups; i++)
        {
            float adjustment = radians * i;
            Vector3 offset = new Vector3(Mathf.Cos(radians + adjustment), Mathf.Sin(radians + adjustment)) * radius;
            Vector3 spawnPosition = transform.position + offset;
            Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);
        }
    }

}