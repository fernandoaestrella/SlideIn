using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public GameManager game;
    public Text timeDisplay;

    // Update is called once per frame
    void Update()
    {
        timeDisplay.text = "Time Remaining: " + (game.matchDuration - game.elapsedTime).ToString("f2");
    }
}
