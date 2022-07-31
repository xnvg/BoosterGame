using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip dSound;
    [SerializeField] AudioClip finishSound;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    AudioSource audioSource;

    bool isTransitioning = false;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        if(isTransitioning)
        {
            return;
        }
        switch(other.gameObject.tag)
        {
            case "Friendly": FriendlyTouchHandler();
            break;
            
            case "Obstacle": StartCrashSequence();
            break;

            case "Fuel": GoodthingTouchHandler();
            break;

            case "Finish": StartSuccessSequence();
            break;


        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        //Todo add SFX upon crash
        crashParticle.Play();
        //audioSource.Stop();
        audioSource.PlayOneShot(dSound);
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        //Todo add SFX upon crash
        successParticle.Play();
        //audioSource.Stop();
        audioSource.PlayOneShot(finishSound);
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void FriendlyTouchHandler()
    {
        Debug.Log("Friendly touch!");
    }

    void ReloadLevel()
    {
        Debug.Log("Obstacle touch!");
        int currentSceneIndex = EditorSceneManager.GetActiveScene().buildIndex;
        EditorSceneManager.LoadScene(currentSceneIndex);
    }

    void GoodthingTouchHandler()
    {
        Debug.Log("Goodthing touch!");
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = EditorSceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == EditorSceneManager.sceneCountInBuildSettings)
        {   
            nextSceneIndex = 0;
        }
        EditorSceneManager.LoadScene(nextSceneIndex); 
        Debug.Log("Finish!");
    }
}
