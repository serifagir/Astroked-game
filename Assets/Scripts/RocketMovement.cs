using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotation = 100f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        RocketThrust();
        RocketRotation();
    }

    private void RocketThrust(){
        if(Input.GetKey(KeyCode.W)){
            rigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }

    private void RocketRotation(){
        if(Input.GetKey(KeyCode.D)){
            ApplyRotation(rotation);
        }else if(Input.GetKey(KeyCode.A)){
            ApplyRotation(-rotation);
        }
    }

    private void ApplyRotation(float rotationPerFrame){
        transform.Rotate(Vector3.forward * rotationPerFrame * Time.deltaTime);
    }
}
