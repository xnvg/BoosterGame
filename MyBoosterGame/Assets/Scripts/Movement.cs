using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float goUpSpeed = 1000f;
    [SerializeField] float rotationThrust = 100f;

    Rigidbody rd;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrusting();
        ProcessRotation();
    }

    void ProcessThrusting()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rd.AddRelativeForce(Vector3.up * Time.deltaTime * goUpSpeed);
        }
        
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotateThisFrame)
    {
        rd.freezeRotation = true;
        
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateThisFrame);

        rd.freezeRotation = false;
    }
}
