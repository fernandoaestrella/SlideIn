using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;

=======
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e

public class Player : MonoBehaviour
{
    public int score;
    public ArrayList team;
    private int startX;
    private int startY;
    private int goalX;
    private int goalY;
    public Color unitColor;
<<<<<<< HEAD
    public Tile startTile;
    public Tile goalTile;
    public GameManager game;
    string playerName;
    public Unit unit;

=======
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e

    public int GoalX { get => goalX; set => goalX = value; }
    public int GoalY { get => goalY; set => goalY = value; }
    public int StartX { get => startX; set => startX = value; }
    public int StartY { get => startY; set => startY = value; }
<<<<<<< HEAD
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
                                selectedUnit.OnMoveNorth();
                                break;
                                case 1:
                                selectedUnit.OnMoveSouth();
                                break;
                                case 2:
                                selectedUnit.OnMoveEast();
                                break;
                                case 3:
                                selectedUnit.OnMoveWest();
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
=======
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
}
