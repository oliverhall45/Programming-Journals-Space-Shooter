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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.left;
            timePassed += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.right;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.down;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

        if (!Input.GetKey(KeyCode.LeftArrow) && (!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.UpArrow)) && (!Input.GetKey(KeyCode.DownArrow)))
        {
            
        }
        
    }

}