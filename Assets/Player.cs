using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// [RequireComponent(typeof(PlayerInput))]

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
    public Unit unit;


    public int GoalX { get => goalX; set => goalX = value; }
    public int GoalY { get => goalY; set => goalY = value; }
    public int StartX { get => startX; set => startX = value; }
    public int StartY { get => startY; set => startY = value; }
    public string PlayerName { get => playerName; set => playerName = value; }


    // private float nextActionTime = 0.0f;
    // public float period = 0.6f;

    void Start()
    {
        if (GameObject.Find("P2").name.Equals(playerName) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine("RandomAI");
        }
    }

    public void createUnit()
    {
        Unit newUnit = Instantiate(unit);
        newUnit.game = game;
        newUnit.tile = startTile;
        newUnit.player = this;
        newUnit.isMoving = false;
        // Tell unit which position it holds
        newUnit.position = newUnit.tile.GetComponent<Transform>().position;
        // Move unit to its position
        newUnit.GetComponent<Transform>().position = newUnit.position;
        // Tell tile which unit it holds
        startTile.unit = newUnit;
        // Makes that tile untraversable
        startTile.isTraversable = false;
        // Color unit
        newUnit.GetComponent<SpriteRenderer>().color = unitColor;
        // Add unit to player's team
        team.Add(newUnit);
    }

    // void Update()
    // {
    //     // if (GameObject.Find("P2").name.Equals(playerName))
    //     // {
    //     //     if (Time.time > nextActionTime)
    //     //     {
    //     //         nextActionTime = Time.time + period;
    //     //     }
    //     // }
    // }

    public void OnMoveNorth()
    {
        foreach (Unit unit in team)
        {
            if (unit.isSelected)
            {
                if (unit.moveCheck(unit.tile.northernTile))
                {
                    unit.move(unit.tile.northernTile, "N");
                }
            }
        }
    }

    public void OnMoveSouth()
    {

        foreach (Unit unit in team)
        {
            if (unit.isSelected)
            {
                if (unit.moveCheck(unit.tile.southernTile))
                {
                    unit.move(unit.tile.southernTile, "S");
                }
            }
        }
    }

    public void OnMoveEast()
    {

        foreach (Unit unit in team)
        {
            if (unit.isSelected)
            {
                if (unit.moveCheck(unit.tile.easternTile))
                {
                    unit.move(unit.tile.easternTile, "E");
                }
            }
        }
    }

    public void OnMoveWest()
    {

        foreach (Unit unit in team)
        {
            if (unit.isSelected)
            {
                if (unit.moveCheck(unit.tile.westernTile))
                {
                    unit.move(unit.tile.westernTile, "W");
                }
            }
        }
    }

    public IEnumerator RandomAI()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.15f);
            bool foundAction = false;

            while (!foundAction)
            {
                int randomAction = UnityEngine.Random.Range(0, 10);
                if (randomAction > 4)
                {
                    if (startTile.unit == null)
                    {
                        createUnit();
                        foundAction = true;
                    }
                }
                else
                {
                    if (team.Count > 0)
                    {
                        int randomUnit = UnityEngine.Random.Range(0, team.Count);
                        Unit selectedUnit = ((Unit)team[randomUnit]);
                        selectedUnit.isSelected = true;
                        int randomDirection = UnityEngine.Random.Range(0, 4);
                        switch (randomDirection)
                        {
                            case 0:
                                OnMoveNorth();
                                break;
                            case 1:
                                OnMoveSouth();
                                break;
                            case 2:
                                OnMoveEast();
                                break;
                            case 3:
                                OnMoveWest();
                                break;
                            default:
                                break;
                        }
                        selectedUnit.unselect();

                        foundAction = true;
                    }
                }
            }
        }
    }
}
