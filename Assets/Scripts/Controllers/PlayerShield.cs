using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public Transform playerTransform;
    public float radius;
    public float orbitalSpeed;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, orbitalSpeed, playerTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = target.position + new Vector3(x, y, 0);

        transform.up = (target.position - transform.position).normalized;
    }
}
