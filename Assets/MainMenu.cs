using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
        // To find the build queue: File > Build Settings
    public void PlayTestMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlaySinglePlayer()
    {
        // Play against AI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
