using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;

    private bool moveRight = true;
    private bool moveLeft = false;
    private bool moveUp = true;
    private bool moveDown = false;
    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Vector3 enemyPosition = transform.position;

        Vector3 topRightOutOfBounds = new Vector3(9f, 9f, 0);
        Vector3 bottomLeftOutOfBounds = new Vector3(-9f, -9f, 0);
        Vector3 middleOfMap = Vector3.zero;

        

        if (enemyPosition.x >= topRightOutOfBounds.x && enemyPosition.y >= topRightOutOfBounds.y && enemyPosition.x >= middleOfMap.x)
        {
            moveRight = false;
            moveLeft = false;
            moveUp = false;
            moveDown = true;
           
        }

        if(enemyPosition.y >= topRightOutOfBounds.y)
        {
            moveRight = false;
            moveUp = false;
            moveDown = true;
            moveLeft = false;
        }

        if (enemyPosition.y <= bottomLeftOutOfBounds.y && enemyPosition.x >= middleOfMap.x && moveDown == true)
        {
            moveRight = false;
            moveLeft = true;
            moveUp = true;
            moveDown = false;
        }

        if (enemyPosition.y <= bottomLeftOutOfBounds.y && enemyPosition.x <= middleOfMap.x && moveDown == true)
        {
            moveRight = true;
            moveLeft = false;
            moveUp = true;
            moveDown = false;
        }

        if (moveRight == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (moveLeft == true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (moveUp == true)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (moveDown == true)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }


    }

}
