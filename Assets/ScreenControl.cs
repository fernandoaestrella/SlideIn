using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    public Player player;


    void OnMouseDown()
    {
        Debug.Log("got it");
        player.OnMoveEast();
    }

}
