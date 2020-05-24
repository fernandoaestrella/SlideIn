using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< HEAD
        // To find the build queue: File > Build Settings
    public void PlayTestMatch()
    {
        SceneManager.LoadScene(1);
=======
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
    }

    public void Quit()
    {
        Application.Quit();
    }
<<<<<<< HEAD

    public void PlaySinglePlayer()
    {
        // Play against AI
        SceneManager.LoadScene(2);
    }
=======
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
}
