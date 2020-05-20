using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool isMoving;
    public string direction; //change to enum
    public Vector3 position;
    public GameManager game;
    public Tile tile;


    void OnMouseUpAsButton() { 
        game.selectedUnit = this;
    }

    void OnMoveNorth() {
        // Debug.Log("moving north");
    }
}
