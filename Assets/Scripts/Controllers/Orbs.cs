using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Orbs : MonoBehaviour
{
    
    public Transform playerObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scoreboardPlacement = new Vector3(-16, 15, 0);
        if (transform.position.x + 0.5f >= playerObject.position.x && transform.position.x - 0.5f <= playerObject.position.x && transform.position.y + 1f >= playerObject.position.y && transform.position.y - 1f <= playerObject.position.y)
        {
            transform.position = scoreboardPlacement;
        }
    }
}
