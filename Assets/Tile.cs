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
}
