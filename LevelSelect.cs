using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Load a certain scene based on string input
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
