using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int a;
    private static SceneManagement _instance; // Private static instance for singleton pattern

    public static SceneManagement Instance // Public property for singleton access
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneManagement>();
                if (_instance == null)
                {
                    Debug.LogError("ButtonManager: No instance found in scene!");
                }
            }

            return _instance;
        }
    }

    private void Awake() // Handle potential duplicate instances
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public void ToStartMenu()
    {
        // Implement logic to transition to the Start Menu scene
        SceneManager.LoadScene("StartMenu"); // Example: Load the "StartMenu" scene
    }

    public void ToGameScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
