using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameModePanel;
    public void ToStartMenu()
    {
        // Implement logic to transition to the Start Menu scene
        SceneManager.LoadScene("StartMenu"); // Example: Load the "StartMenu" scene
    }

    public void StartButton()
    {
       gameModePanel.SetActive(true);
       
    }

    public void EasyMode()
    {
        PlayerPrefs.SetString("gameMode","Easy");
        SceneManager.LoadScene("GameScene");  
    }

    public void MediumMode()
    {
        PlayerPrefs.SetString("gameMode","Medium");
        SceneManager.LoadScene("GameScene");  
    }

    public void HardMode()
    {
        PlayerPrefs.SetString("gameMode","Hard");
        SceneManager.LoadScene("GameScene");  
    }

    
}
