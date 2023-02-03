using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject ceilingPrefab;
    private GameObject[] generatedGrounds;
    private GameObject[] generatedCeilings;
    private Vector3 groundInstantiatePosition;
    private Vector3 ceilingInstantiatePosition;
    private int groundObjectsIndex;
    private int ceilingObjectsIndex;
    public Transform player;
    public int createdGroundSameTime = 5;
    public int createdCeilingSameTime = 5;
    void Start()
    {
        generatedGrounds = new GameObject[createdGroundSameTime];
        for(int i = 0; i < createdGroundSameTime; i++){
            CreateLevelGround();
            
        }

        generatedCeilings = new GameObject[createdCeilingSameTime];
        for(int i = 0; i < createdCeilingSameTime; i++){
            CreateLevelCeiling();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > groundInstantiatePosition.x - 50){
            CreateGround();
            CreateCeiling();
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

    private void CreateCeiling(){
        generatedCeilings[ceilingObjectsIndex].transform.position = ceilingInstantiatePosition;
        ceilingInstantiatePosition.y = 40f;
        ceilingInstantiatePosition += new Vector3(50f, 0f, 0f);
        ceilingObjectsIndex++;
        if(ceilingObjectsIndex >= createdCeilingSameTime){
            ceilingObjectsIndex = 0;
        }
    }

    private void CreateLevelGround(){
        GameObject groundGameObject = Instantiate(groundPrefab, groundInstantiatePosition, Quaternion.identity);
        generatedGrounds[groundObjectsIndex] = groundGameObject;
        groundInstantiatePosition += new Vector3(50f, 0f, 0f);
        groundObjectsIndex++;
        if(groundObjectsIndex >= createdGroundSameTime){
            groundObjectsIndex = 0;
        }
    }

    private void CreateLevelCeiling(){
        GameObject ceilingGameObject = Instantiate(ceilingPrefab, ceilingInstantiatePosition, Quaternion.identity);
        generatedCeilings[ceilingObjectsIndex] = ceilingGameObject;
        ceilingInstantiatePosition.y = 40f;
        ceilingInstantiatePosition.x = 50f;
        ceilingInstantiatePosition += new Vector3(50f, 0f, 0f);
        ceilingObjectsIndex++;
        if(ceilingObjectsIndex >= createdCeilingSameTime){
            ceilingObjectsIndex = 0;
        }
    }
}
