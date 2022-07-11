using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float goUpSpeed = 1000f;

    Rigidbody rd;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SpaceEventListener();
    }

    void SpaceEventListener()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rd.AddForce(Vector3.up*Time.deltaTime*goUpSpeed);
        }
        
    }
}
