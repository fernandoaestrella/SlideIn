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
    public GameManager game;
    string playerName;

    public int GoalX { get => goalX; set => goalX = value; }
    public int GoalY { get => goalY; set => goalY = value; }
    public int StartX { get => startX; set => startX = value; }
    public int StartY { get => startY; set => startY = value; }
    public string PlayerName { get => playerName; set => playerName = value; }


    private float nextActionTime = 0.0f;
    public float period = 0.6f;

    void Update()
    {
        if (GameObject.Find("P2").name.Equals(playerName))
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
            }
        }
    }
}
