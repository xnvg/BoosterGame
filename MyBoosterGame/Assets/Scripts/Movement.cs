using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float goUpSpeed = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainSound;

    [SerializeField] ParticleSystem mainThrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;

    Rigidbody rd;
    AudioSource audioSource;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if(!audioSource.isPlaying)
            {
                //audioSource.Play();
                audioSource.PlayOneShot(mainSound);
            }
            if(!mainThrustParticle.isPlaying){
                mainThrustParticle.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainThrustParticle.Stop();
        }
        
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if(!rightThrustParticle.isPlaying){
                rightThrustParticle.Play();
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if(!leftThrustParticle.isPlaying){
                leftThrustParticle.Play();
            }
        }
        else{
            leftThrustParticle.Stop();
            rightThrustParticle.Stop();
        }
    }

    private void ApplyRotation(float rotateThisFrame)
    {
        rd.freezeRotation = true;

        transform.Rotate(Vector3.forward * Time.deltaTime * rotateThisFrame);

        rd.freezeRotation = false;
    }
}
