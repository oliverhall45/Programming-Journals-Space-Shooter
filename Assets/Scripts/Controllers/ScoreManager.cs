using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using System.Collections.Generic;

public class ScoreOrbsManager : MonoBehaviour
{
   
    public Transform playerObject;
    public GameObject enemy;
    public List<Transform> scoreOrb;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scoreOrb.Count; i++)
        {
            if (IsPlayerTouching(scoreOrb[i].position))
            {
                score++;
                CountPointsCollected();
            }
        }

        bool IsPlayerTouching(Vector3 orbPos)
        {
            return
                orbPos.x + 0.5f >= playerObject.position.x &&
                orbPos.x - 0.5f <= playerObject.position.x &&
                orbPos.y + 1f >= playerObject.position.y &&
                orbPos.y - 1f <= playerObject.position.y;
        }
    }
    
    private void CountPointsCollected()
    {
        if (score >= 10)
        {
            Destroy(enemy);
        }
    }
}