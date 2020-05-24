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
    bool fadingOff = true;
    public Player player;
    public bool isSelected = false;
    public bool isBlinking = false;

    void OnMouseUpAsButton()
    {
        isSelected = true;
    }

    Boolean moveCheck(Tile tileToMoveTo)
    {
        if ((isMoving == false) && isSelected && unitCanMove(tileToMoveTo))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnMoveNorth()
    {
        if (moveCheck(tile.northernTile))
        {
            move(tile.northernTile, "N");
        }
    }

    public void OnMoveSouth()
    {
        if (moveCheck(tile.southernTile))
        {
            move(tile.southernTile, "S");
        }
    }

    public void OnMoveEast()
    {
        if (moveCheck(tile.easternTile))
        {
            move(tile.easternTile, "E");
        }
    }

    public void OnMoveWest()
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

    // Coroutine to optimize performance
    public IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.0053f);
            // Blink selected unit
            Color tmp = this.GetComponent<SpriteRenderer>().color;
            if (fadingOff)
            {
                tmp.a *= 0.98f;

                if (tmp.a < 0.5f)
                {
                    fadingOff = false;
                }
            }
            else
            {
                tmp.a *= 1.02f;

                if (tmp.a > 0.98f)
                {
                    fadingOff = true;
                }
            }
            this.GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    // public void blink()
    // {
    //     // Blink selected unit
    //     Color tmp = this.GetComponent<SpriteRenderer>().color;
    //     if (blinkingOff)
    //     {
    //         tmp.a *= 0.98f;

    //         if (tmp.a < 0.5f)
    //         {
    //             blinkingOff = false;
    //         }
    //     }
    //     else
    //     {
    //         tmp.a *= 1.02f;

    //         if (tmp.a > 0.98f)
    //         {
    //             blinkingOff = true;
    //         }
    //     }
    //     this.GetComponent<SpriteRenderer>().color = tmp;
    // }

    public void remove()
    {
        isMoving = false;
        isSelected = false;
        tile.isTraversable = true;
        this.player.team.Remove(this);
        Destroy(this.GetComponent<SpriteRenderer>());
        Destroy(this.gameObject);
    }

    void playChecker()
    {
        switch (direction)
        {
            case "N":
                if (tile.northernTile != null && tile.northernTile.unit != null && tile.northernTile.northernTile != null && tile.northernTile.northernTile.unit != null && tile.northernTile.northernTile.northernTile != null && tile.northernTile.northernTile.northernTile.unit != null)
                {
                    if (tile.northernTile.unit.player.startTile.Equals(player.startTile) && tile.northernTile.northernTile.unit.player.startTile.Equals(player.startTile) && !tile.northernTile.northernTile.northernTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.northernTile.northernTile.northernTile.unit.remove();
                        tile.northernTile.northernTile.unit.remove();
                        tile.northernTile.unit.remove();
                        tile.unit.remove();
                        player.score += 1;
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
                if (tile.southernTile != null && tile.southernTile.unit != null && tile.southernTile.southernTile != null && tile.southernTile.southernTile.unit != null && tile.southernTile.southernTile.southernTile != null && tile.southernTile.southernTile.southernTile.unit != null)
                {
                    if (tile.southernTile.unit.player.startTile.Equals(player.startTile) && tile.southernTile.southernTile.unit.player.startTile.Equals(player.startTile) && !tile.southernTile.southernTile.southernTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.southernTile.southernTile.southernTile.unit.remove();
                        tile.southernTile.southernTile.unit.remove();
                        tile.southernTile.unit.remove();
                        tile.unit.remove();
                        player.score += 1;
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
                if (tile.easternTile != null && tile.easternTile.unit != null && tile.easternTile.easternTile != null && tile.easternTile.easternTile.unit != null && tile.easternTile.easternTile.easternTile != null && tile.easternTile.easternTile.easternTile.unit != null)
                {
                    if (tile.easternTile.unit.player.startTile.Equals(player.startTile) && tile.easternTile.easternTile.unit.player.startTile.Equals(player.startTile) && !tile.easternTile.easternTile.easternTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.easternTile.easternTile.easternTile.unit.remove();
                        tile.easternTile.easternTile.unit.remove();
                        tile.easternTile.unit.remove();
                        tile.unit.remove();
                        player.score += 1;
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
                if (tile.westernTile != null && tile.westernTile.unit != null && tile.westernTile.westernTile != null && tile.westernTile.westernTile.unit != null && tile.westernTile.westernTile.westernTile != null && tile.westernTile.westernTile.westernTile.unit != null)
                {
                    if (tile.westernTile.unit.player.startTile.Equals(player.startTile) && tile.westernTile.westernTile.unit.player.startTile.Equals(player.startTile) && !tile.westernTile.westernTile.westernTile.unit.player.startTile.Equals(player.startTile))
                    {
                        tile.westernTile.westernTile.westernTile.unit.remove();
                        tile.westernTile.westernTile.unit.remove();
                        tile.westernTile.unit.remove();
                        tile.unit.remove();
                        player.score += 1;
                    }
                }
                else if (tile.westernTile != null && tile.westernTile.unit != null && tile.westernTile.westernTile != null && tile.westernTile.westernTile.unit != null && tile.westernTile.westernTile.westernTile != null)
                {
                    if (tile.westernTile.unit.player.startTile.Equals(player.startTile) && !tile.westernTile.westernTile.unit.player.startTile.Equals(player.startTile) && tile.westernTile.westernTile.westernTile.isTraversable)
                    {
                        tile.westernTile.westernTile.unit.place(tile.westernTile.westernTile.westernTile);
                    }
                }
                break;
        }


    }

    public void unselect()
    {
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 1;
        this.GetComponent<SpriteRenderer>().color = tmp;
        StopCoroutine("Blink");
        isBlinking = false;
        isSelected = false;
    }

    void Update()
    {
        if (isMoving)
        {
            if (tile.Equals(player.goalTile))
            {
                player.score += 2;
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

                    if (((Player)player).team.Contains(this))
                    {
                        direction = "";
                        isMoving = false;
                        tile.isTraversable = false;

                    }
                }
            }

        }
        else
        {
            if (isSelected && !isBlinking)
            {
                StartCoroutine("Blink");
                isBlinking = true;
                // blink();
            }
        }
    }
}
