using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isTraversable;
    public Unit unit;
    public Modifier modifier;
    public Tile easternTile;
    public Tile westernTile;
    public Tile northernTile;
    public Tile southernTile;
    public GameManager game;

    void OnMouseUpAsButton()
    {
        Debug.Log(game);
        if (modifier.modifierName.Equals("START"))
        {
            if (isTraversable)
            {
                ((Player)game.players[0]).createUnit();
            }
        }
        else if (modifier.modifierName.Equals("GOAL"))
        {
            if (isTraversable)
            {
                ((Player)game.players[1]).createUnit();
            }
        }
        else
        {
            foreach (Player player in game.players)
            {
                foreach (Unit unit in player.team)
                {
                    if (unit.isSelected == true)
                    {
                        unit.unselect();
                    }
                }
            }
        }
    }
}
