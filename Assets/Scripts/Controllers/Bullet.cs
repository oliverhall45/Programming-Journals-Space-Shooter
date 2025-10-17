using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public Transform shieldTransform;
    public Transform playerPos;
    public GameObject player;
    private Vector3 moveDirection;
    private float moveSpeed;
    public float hitDistance = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        if (shieldTransform != null && Vector3.Distance(transform.position, shieldTransform.position) <= hitDistance)
        {
            Destroy(gameObject);
        }

        if (transform.position.x + 0.5f >= playerPos.position.x && transform.position.x - 0.5f <= playerPos.position.x && transform.position.y + 0.5f >= playerPos.position.y && transform.position.y - 0.5f <= playerPos.position.y)
        {
            Destroy(player);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetTarget(Transform newTarget)
    {
        shieldTransform = newTarget;
    }
}
