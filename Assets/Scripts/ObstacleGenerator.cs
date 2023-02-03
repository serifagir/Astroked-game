using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstaclePassedPrefab;
    
    public Transform rocket;
    public float minX = 20f;
    public float maxX ;
    public float minY = 7;
    public float maxY = 40;

    private GameObject[] generatedObstacles;
    
    public float distanceToPlayer;

    int spawnedObstacles = 0;
    

    void Start()
    {
       
    }

    void Update(){
        while(spawnedObstacles<=1){
            instantiateObstacle();
            }
        if(rocket.transform.position.x >  obstaclePrefab.transform.position.x ){
            Destroy(obstaclePrefab,0f);
            Instantiate(obstaclePassedPrefab, new Vector3(obstaclePrefab.transform.position.x, 22f, 0f), Quaternion.identity);
        
        }

        
            

    }


    void instantiateObstacle(){
        float randomX = rocket.transform.position.x+50f;
        
        float randomY = Random.Range(minY, maxY);
        Vector3 randomPosition = new Vector3(randomX, randomY);
        Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
        spawnedObstacles+=1;
    }

}
