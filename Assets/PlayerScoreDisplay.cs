using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreDisplay : MonoBehaviour
{
    public GameManager game;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Player 1 Score: " + ((Player)game.players[0]).score + "\n\n\nPlayer 2 Score: " + ((Player)game.players[1]).score;
    }
}
