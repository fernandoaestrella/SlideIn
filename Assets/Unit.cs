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
    bool blinkingOff = true;
    public Player player;

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

    public void blink()
    {
        // Blink selected unit
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        if (blinkingOff)
        {
            tmp.a *= 0.98f;

            if (tmp.a < 0.5f)
            {
                blinkingOff = false;
            }
        }
        else
        {
            tmp.a *= 1.02f;

            if (tmp.a > 0.98f)
            {
                blinkingOff = true;
            }
        }
        this.GetComponent<SpriteRenderer>().color = tmp;
    }

    public void remove()
    {
        Destroy(this.GetComponent<SpriteRenderer>());
        Destroy(this.gameObject);
        this.player.score += 1;
        // movingUnits.Remove(selectedUnit);
        game.selectedUnit = null;
    }

    void Update()
    {
        if (isMoving)
        {
            if (tile.modifier.modifierName.Equals("GOAL"))
            {
                if (((Player) game.players[0]).Equals(this.player))
                {
                    remove();
                }
            }
            else if (tile.modifier.modifierName.Equals("START"))
            {
                if (((Player) game.players[1]).Equals(this.player))
                {
                    remove();
                }
            }

            if ((direction.Equals("E")) && unitCanMove(tile.easternTile))
            {
                move(tile.easternTile, "E");
            }
            else if ((direction.Equals("W")) && unitCanMove(tile.westernTile))
            {
                move(tile.westernTile, "W");
            }
            else if ((direction.Equals("N")) && unitCanMove(tile.northernTile))
            {
                move(tile.northernTile, "N");
            }
            else if ((direction.Equals("S")) && unitCanMove(tile.southernTile))
            {
                move(tile.southernTile, "S");
            }
            else
            {
                // Stop moving
                direction = "";
                isMoving = false;
                tile.isTraversable = false;
            }
        }
    }
}
