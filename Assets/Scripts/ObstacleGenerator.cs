using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform rocket;
    public float minY = 7;
    public float maxY = 40;
    public int amountOfObstacles = 25;

    private GameObject[] generatedObstacles;
    
    public float distanceToPlayer;

    int spawnedObstacles = 0;
    

    void Start()
    {
        instantiateObstacle();
    }

    void Update(){
        
    }

    void instantiateObstacle(){
        float xPosition = 25f;
        for(int i = 0; i<amountOfObstacles;i++){
            float yPositionRandom = Random.Range(minY, maxY);
            Vector3 randomPosition = new Vector3(xPosition, yPositionRandom);
            Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
            xPosition += 25f;
        }
        
    }


    

}
