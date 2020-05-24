using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerDisplay : MonoBehaviour
{
    public GameManager game;
    public Text matchResultsText;
    public GameObject matchResultsPanel;

    // Update is called once per frame
    void Update()
    {
        if (((Player)game.players[0]).score > ((Player)game.players[1]).score)
        {
            matchResultsText.text = "P1 WINS";
        }
        else if (((Player)game.players[0]).score < ((Player)game.players[1]).score)
        {
            matchResultsText.text = "P2 WINS";
        }
        else
        {
            matchResultsText.text = "ITS A TIE!";
        }
    }

    public void BackToMenu()
    {
<<<<<<< HEAD
        SceneManager.LoadScene(0);
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
