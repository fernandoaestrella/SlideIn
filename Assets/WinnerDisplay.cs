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
        int p1score = ((Player)game.players[0]).score;
        int p2score = ((Player)game.players[1]).score;
        if ( p1score > p2score)
        {
            matchResultsText.text = "P1 WINS! P1: " + p1score + ", P2: " + p2score;
        }
        else if (p1score < p2score)
        {
            matchResultsText.text = "P2 WINS! P1: " + p1score + ", P2: " + p2score;
        }
        else
        {
            matchResultsText.text = "ITS A TIE!";
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
