using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Friendly": FriendlyTouchHandler();
            break;
            
            case "Obstacle": ObstacleTouchHandler();
            break;

            case "Fuel": GoodthingTouchHandler();
            break;

            case "Finish": FinishTouchHandler();
            break;


        }
    }

    void FriendlyTouchHandler()
    {
        Debug.Log("Friendly touch!");
    }

    void ObstacleTouchHandler()
    {
        Debug.Log("Obstacle touch!");
        int currentSceneIndex = EditorSceneManager.GetActiveScene().buildIndex;
        EditorSceneManager.LoadScene(currentSceneIndex);
    }

    void GoodthingTouchHandler()
    {
        Debug.Log("Goodthing touch!");
    }

    void FinishTouchHandler()
    {
        Debug.Log("Finish!");
    }
}
