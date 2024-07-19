using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
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
