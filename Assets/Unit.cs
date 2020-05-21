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
        this.isMoving = true;
        this.direction = direction;
        place(tileToMoveTo);
    }

    public void place(Tile tileToMoveTo)
    {
        tile.unit = null;
        tile.isTraversable = true;
        this.position = tileToMoveTo.GetComponent<Transform>().position;
        this.GetComponent<Transform>().position = this.position;
        this.tile = tileToMoveTo;
        tileToMoveTo.unit = this;
        tileToMoveTo.isTraversable = false;
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
        game.selectedUnit = null;
        tile.isTraversable = true;
    }

    void playChecker()
    {
        switch (direction)
        {
            case "N":
                if (tile.northernTile != null && tile.northernTile.unit != null && tile.northernTile.northernTile != null && tile.northernTile.northernTile.unit != null && tile.northernTile.northernTile.northernTile != null && tile.northernTile.northernTile.northernTile.unit != null && tile.northernTile.northernTile.northernTile.northernTile != null)
                {
                    if (tile.northernTile.unit.player.startTile.Equals(player.startTile) && tile.northernTile.northernTile.unit.player.startTile.Equals(player.startTile) && !tile.northernTile.northernTile.northernTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.northernTile.northernTile.northernTile.unit.remove();
                    }
                }
                else if (tile.northernTile != null && tile.northernTile.unit != null && tile.northernTile.northernTile != null && tile.northernTile.northernTile.unit != null && tile.northernTile.northernTile.northernTile != null)
                {
                    if (tile.northernTile.unit.player.startTile.Equals(player.startTile) && !tile.northernTile.northernTile.unit.player.startTile.Equals(player.startTile) && tile.northernTile.northernTile.northernTile.isTraversable)
                    {
                        tile.northernTile.northernTile.unit.place(tile.northernTile.northernTile.northernTile);
                    }
                }
                break;
            case "S":
                if (tile.southernTile != null && tile.southernTile.unit != null && tile.southernTile.southernTile != null && tile.southernTile.southernTile.unit != null && tile.southernTile.southernTile.southernTile != null && tile.southernTile.southernTile.southernTile.unit != null && tile.southernTile.southernTile.southernTile.southernTile != null)
                {
                    if (tile.southernTile.unit.player.startTile.Equals(player.startTile) && tile.southernTile.southernTile.unit.player.startTile.Equals(player.startTile) && !tile.southernTile.southernTile.southernTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.southernTile.southernTile.southernTile.unit.remove();
                    }
                }
                else if (tile.southernTile != null && tile.southernTile.unit != null && tile.southernTile.southernTile != null && tile.southernTile.southernTile.unit != null && tile.southernTile.southernTile.southernTile != null)
                {
                    if (tile.southernTile.unit.player.startTile.Equals(player.startTile) && !tile.southernTile.southernTile.unit.player.startTile.Equals(player.startTile) && tile.southernTile.southernTile.southernTile.isTraversable)
                    {
                        tile.southernTile.southernTile.unit.place(tile.southernTile.southernTile.southernTile);
                    }
                }
                break;
            case "E":
                if (tile.easternTile != null && tile.easternTile.unit != null && tile.easternTile.easternTile != null && tile.easternTile.easternTile.unit != null && tile.easternTile.easternTile.easternTile != null && tile.easternTile.easternTile.easternTile.unit != null && tile.easternTile.easternTile.easternTile.easternTile != null)
                {
                    if (tile.easternTile.unit.player.startTile.Equals(player.startTile) && tile.easternTile.easternTile.unit.player.startTile.Equals(player.startTile) && !tile.easternTile.easternTile.easternTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.easternTile.easternTile.easternTile.unit.remove();
                    }
                }
                else if (tile.easternTile != null && tile.easternTile.unit != null && tile.easternTile.easternTile != null && tile.easternTile.easternTile.unit != null && tile.easternTile.easternTile.easternTile != null)
                {
                    if (tile.easternTile.unit.player.startTile.Equals(player.startTile) && !tile.easternTile.easternTile.unit.player.startTile.Equals(player.startTile) && tile.easternTile.easternTile.easternTile.isTraversable)
                    {
                        tile.easternTile.easternTile.unit.place(tile.easternTile.easternTile.easternTile);
                    }
                }
                break;
            case "W":
                if (tile.westernTile != null && tile.westernTile.unit != null && tile.westernTile.westernTile != null && tile.westernTile.westernTile.unit != null && tile.westernTile.westernTile.westernTile != null && tile.westernTile.westernTile.westernTile.unit != null && tile.westernTile.westernTile.westernTile.westernTile != null)
                {
                    if (tile.westernTile.unit.player.startTile.Equals(player.startTile) && tile.westernTile.westernTile.unit.player.startTile.Equals(player.startTile) && !tile.westernTile.westernTile.westernTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.westernTile.westernTile.westernTile.unit.remove();
                    }
                }
                else if (tile.westernTile != null && tile.westernTile.unit != null && tile.westernTile.westernTile != null && tile.westernTile.westernTile.unit != null && tile.westernTile.westernTile.westernTile  != null)
                {
                    if (tile.westernTile.unit.player.startTile.Equals(player.startTile) && !tile.westernTile.westernTile.unit.player.startTile.Equals(player.startTile) && tile.westernTile.westernTile.westernTile.isTraversable)
                    {
                        tile.westernTile.westernTile.unit.place(tile.westernTile.westernTile.westernTile);
                    }
                }
                break;
        }


    }

    void Update()
    {
        if (isMoving)
        {
            if (tile.Equals(player.goalTile))
            {
                remove();
            }
            else
            {
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
                    if (!direction.Equals(""))
                    {
                        playChecker();
                    }
                    direction = "";
                    isMoving = false;
                    tile.isTraversable = false;
                }
            }

        }
        else
        {
            if (this.Equals(game.selectedUnit))
            {
                blink();
            }
        }
    }
}
