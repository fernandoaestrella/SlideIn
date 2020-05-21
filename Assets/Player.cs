using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public ArrayList team;
    private int startX;
    private int startY;
    private int goalX;
    private int goalY;
    public Color unitColor;
    public Tile startTile;
    public Tile goalTile;

    public int GoalX { get => goalX; set => goalX = value; }
    public int GoalY { get => goalY; set => goalY = value; }
    public int StartX { get => startX; set => startX = value; }
    public int StartY { get => startY; set => startY = value; }
}
