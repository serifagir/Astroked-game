using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    private GameObject[] generatedGrounds;
    private Vector3 groundInstantiatePosition;
    private int groundObjectsIndex;
    public Transform player;
    public int createdGroundSameTime = 5;
    void Start()
    {
        generatedGrounds = new GameObject[createdGroundSameTime];
        for(int i = 0; i < createdGroundSameTime; i++){
            CreateLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > groundInstantiatePosition.x - 50){
            CreateGround();
        }
        
    }

    private void CreateGround(){
        generatedGrounds[groundObjectsIndex].transform.position = groundInstantiatePosition;
        groundInstantiatePosition += new Vector3(50f, 0f, 0f);
        groundObjectsIndex++;
        if(groundObjectsIndex >= createdGroundSameTime){
            groundObjectsIndex = 0;
        }
    }

    private void CreateLevel(){
        GameObject groundGameObject = Instantiate(groundPrefab, groundInstantiatePosition, Quaternion.identity);
        generatedGrounds[groundObjectsIndex] = groundGameObject;
        groundInstantiatePosition += new Vector3(50f, 0f, 0f);
        groundObjectsIndex++;
        if(groundObjectsIndex >= createdGroundSameTime){
            groundObjectsIndex = 0;
        }
    }
}
