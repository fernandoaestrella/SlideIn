using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    public Player player;

    void OnMouseUpAsButton()
    {
        if (this.Equals(GameObject.Find("Move East Button").GetComponent<ScreenControl>()))
        {
            player.OnMoveEast();
        }
        else if (this.Equals(GameObject.Find("Move West Button").GetComponent<ScreenControl>()))
        {
            player.OnMoveWest();
        }
        else if (this.Equals(GameObject.Find("Move North Button").GetComponent<ScreenControl>()))
        {
            player.OnMoveNorth();
        }
        else if (this.Equals(GameObject.Find("Move South Button").GetComponent<ScreenControl>()))
        {
            player.OnMoveSouth();
        }
    }
}
