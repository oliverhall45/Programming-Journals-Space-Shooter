using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public float bombTrailSpacing;
    public int numberOfTrailBombs;
    public float distanceFromPlayer;
    public float positionRatio;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner(distanceFromPlayer);
        }

        if (Input.GetKey(KeyCode.D))
        {
            WarpPlayer(enemyTransform, positionRatio);
            positionRatio += 0.001f;

        }

        if (positionRatio > 1f)
        {
            positionRatio = 1f;
        }
    }

    private void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            Vector3 spawnPosition = transform.position - new Vector3(0, i * inBombSpacing, 0);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector3[] cornerSpawnPositions = new Vector3[] //spawn corners
        {
        new Vector3(-inDistance, -inDistance, 0),
        new Vector3(-inDistance, inDistance, 0),
        new Vector3(inDistance, inDistance, 0),
        new Vector3(inDistance, -inDistance, 0)
        };

        int randomPosition = Random.Range(0, cornerSpawnPositions.Length); //allows the bombs to be spawned in 1 of the 4 corners

        Vector3 randomSpawnPoint = cornerSpawnPositions[randomPosition]; //randomly selects a position to spawn bombs at
    
       
        Instantiate(bombPrefab, randomSpawnPoint, Quaternion.identity); //instantiate the bombs
    }

    public void WarpPlayer(Transform target, float ratio)
    {

        transform.position = Vector3.Lerp(transform.position, target.position, ratio / 100f);


    }
}
