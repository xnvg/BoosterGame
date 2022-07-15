using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    private void OnCollisionEnter(Collision other) {
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
        //Todo add SFX upon crash
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        //Todo add SFX upon crash
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
