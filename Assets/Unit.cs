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


    void OnMouseUpAsButton()
    {
        // game.selectedUnit = this;
    }

    Boolean moveCheck(Tile tileToMoveTo)
    {
        if ((isMoving == false) && game.selectedUnit.Equals(this) && unitCanMove(tileToMoveTo))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMoveNorth()
    {
        if (moveCheck(tile.northernTile))
        {
            move(tile.northernTile, "N");
        }
    }

    void OnMoveSouth()
    {
        if (moveCheck(tile.southernTile))
        {
            move(tile.southernTile, "S");
        }
    }

    void OnMoveEast()
    {
        if (moveCheck(tile.easternTile))
        {
            move(tile.easternTile, "E");
        }
    }

    void OnMoveWest()
    {
        if (moveCheck(tile.westernTile))
        {
            move(tile.westernTile, "W");
        }
    }

    public Boolean unitCanMove(Tile tileToMoveTo)
    {
        if ((tileToMoveTo != null) && (tileToMoveTo.isTraversable))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void move(Tile tileToMoveTo, string direction)
    {
        tile.unit = null;
        tile.isTraversable = true;
        this.isMoving = true;
        this.direction = direction;
        this.position = tileToMoveTo.GetComponent<Transform>().position;
        this.GetComponent<Transform>().position = this.position;
        this.tile = tileToMoveTo;
        this.tile.unit = this;
        if (!game.movingUnits.Contains(this))
        {
            // Debug.Log("contained!");
        }
    }
}
