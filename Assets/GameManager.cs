using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.InputSystem;

//Debug.Log(Time.deltaTime);
public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameBoard currentGameBoard;
    public Tile tile;
    public Unit unit;
    public Unit selectedUnit;
    public ArrayList selectedUnits;
    public ArrayList players;
    public Player player;
=======

public class GameManager : MonoBehaviour
{
    public GameBoard currentGameBoard;
    public Tile tile;
    public Unit currentUnit;
>>>>>>> 6d940a05425dd8e3018fd3826b71c968b53557b6
    Tile currentTile;
    Tile easternTile;
    Tile westernTile;
    Tile northernTile;
    Tile southernTile;
<<<<<<< HEAD

    public float startTime;
    public float elapsedTime;
    public float matchDuration;
    public GameObject inGameCanvas;

    // Start is called before the first frame update
    public void Start()
    {
        startTime = Time.time;
        elapsedTime = 0f;
        matchDuration = 40f;

        createBoard();

        players = new ArrayList(16); // Initial size set to avoid some overflow cycles (wherein inserting an element in the array exceeds its capacity and activates a script that creates a new, bigger array)
        // players.Insert(0, new Player(this));
        // players.Insert(1, new Player(this));
        // Player p = new Player(this);
        // GameObject.Find("Player").GetComponent<Player>();
        Player p =  Instantiate(player);
        p.name = "P1";
        p.PlayerName = "P1";
        players.Insert(0, p);
        
        p =  Instantiate(player);
        p.name = "P2";
        p.PlayerName = "P2";
        players.Insert(1, p);

        // Set team size
        ((Player)players[0]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles
        ((Player)players[1]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles

        // Set player 1 starting position
        ((Player)players[0]).StartX = 1;
        ((Player)players[0]).StartY = 4;
        ((Player)players[0]).startTile = this.currentGameBoard.board[1, 4];
        ((Player)players[0]).goalTile = this.currentGameBoard.board[11, 4];


        ((Player)players[1]).StartX = 11;
        ((Player)players[1]).StartY = 4;
        ((Player)players[1]).startTile = this.currentGameBoard.board[11, 4];
        ((Player)players[1]).goalTile = this.currentGameBoard.board[1, 4];


        // Set team colors
        ((Player)players[0]).unitColor = new Color(0.5f, 0.98f, 0.89f, 1);
        ((Player)players[1]).unitColor = new Color(1.0f, 0.4f, 0.8f, 1);
    }

    // private Unit createUnit(Player player)
    // {
        
    // }

    private void createBoard()
    {
        currentGameBoard.board = new Tile[13, 9];
=======
    int score;

    // Start is called before the first frame update
    void Start()
    {
        createBoard();

        createUnit();
    }

    private void createUnit()
    {
        currentUnit = Instantiate(currentUnit);
        // Tell unit which position it holds
        currentUnit.position = currentGameBoard.board[1, 1].GetComponent<Transform>().position;
        // Move unit to its position
        currentUnit.GetComponent<Transform>().position = currentUnit.position;
        // Tell tile which unit it holds
        currentGameBoard.board[1, 1].unit = currentUnit;
    }

    private void createBoard()
    {
        currentGameBoard.board = new Tile[15, 9];
>>>>>>> 6d940a05425dd8e3018fd3826b71c968b53557b6

        for (int i = 0; i < currentGameBoard.board.GetLength(0); i++)
        {
            for (int j = 0; j < currentGameBoard.board.GetLength(1); j++)
            {
                // Add traversable tiles
                Tile currentTile = Instantiate(tile);
                currentTile.isTraversable = true;
                currentTile.GetComponent<Transform>().position = new Vector3(i, j, 0);
                currentTile.modifier = new Modifier();
                currentTile.modifier.modifierName = "TILE";

                // Change tile colors intermitently
                if ((i + j) % 2 == 0)
                {
                    currentTile.GetComponent<SpriteRenderer>().color = Color.gray;
                }

<<<<<<< HEAD
                // // Make top and bottom row untraversable
                // if ((j == 0) || (j == currentGameBoard.board.GetLength(1) - 1))
                // {
                //     currentTile.modifier.modifierName = "UNPASSABLE";
                //     currentTile.isTraversable = false;
                //     currentTile.GetComponent<SpriteRenderer>().color = Color.black;
                // }

                // Save the tile in the gameboard
                currentGameBoard.board[i, j] = currentTile;

                // Debug.Log(i + ", " + j);
            }
        }



        for (int i = 0; i < currentGameBoard.board.GetLength(0); i++)
        {
            for (int j = 0; j < currentGameBoard.board.GetLength(1); j++)
            {
                Tile currentTile = currentGameBoard.board[i, j];

                // Debug.Log(i + ", " + j);
                // Debug.Log(currentGameBoard.board.GetLength(0) + ", " + currentGameBoard.board.GetLength(1));


                if (i > 0)
                {
                    currentTile.westernTile = currentGameBoard.board[i - 1, j];
                }

                if (i < currentGameBoard.board.GetLength(0) - 1)
                {
                    currentTile.easternTile = currentGameBoard.board[i + 1, j];
                }

                if (j > 0)
                {
                    currentTile.southernTile = currentGameBoard.board[i, j - 1];
                }

                if (j < currentGameBoard.board.GetLength(1) - 1)
                {
                    currentTile.northernTile = currentGameBoard.board[i, j + 1];
                }
            }
        }

        currentGameBoard.board[1, 4].modifier.modifierName = "START";
        currentGameBoard.board[1, 4].GetComponent<SpriteRenderer>().color = Color.blue;
        currentGameBoard.board[11, 4].modifier.modifierName = "GOAL";
        currentGameBoard.board[11, 4].GetComponent<SpriteRenderer>().color = Color.red;

        // Random placement of untraversable blocks
        for (int i = 0; i < 22; i++)
        {
            bool found = false;

            while (!found)
            {
                int randomX = UnityEngine.Random.Range(0, currentGameBoard.board.GetLength(0));
                int randomY = UnityEngine.Random.Range(0, currentGameBoard.board.GetLength(1));

                Tile currentTile = currentGameBoard.board[randomX, randomY];
                if (currentTile.modifier.modifierName != "START" && currentTile.modifier.modifierName != "GOAL" && currentTile.isTraversable)
                {
                    currentTile.modifier.modifierName = "UNPASSABLE";
                    currentTile.isTraversable = false;
                    currentTile.GetComponent<SpriteRenderer>().color = Color.black;
                    found = true;
                }
            }

=======
                // Make top and bottom row untraversable
                if ((j == 0) || (j == currentGameBoard.board.GetLength(1) - 1))
                {
                    currentTile.modifier.modifierName = "UNPASSABLE";
                    currentTile.isTraversable = false;
                    currentTile.GetComponent<SpriteRenderer>().color = Color.black;
                }

                // Set the goal
                if ((i == 14) && (j == 4))
                {
                    currentTile.GetComponent<SpriteRenderer>().color = Color.red;
                    currentTile.modifier.modifierName = "GOAL";
                }

                // Save the tile in the gameboard
                currentGameBoard.board[i, j] = currentTile;

                Debug.Log(i + ", " + j);
            }
>>>>>>> 6d940a05425dd8e3018fd3826b71c968b53557b6
        }
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        elapsedTime = Time.time - startTime;
        if (elapsedTime > matchDuration)
        {
            inGameCanvas.SetActive(true);

            // Stop controlling players
        }

        if (Input.GetMouseButtonDown(0))
        {
            int layerMask = 1 << 9;
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.forward, Mathf.Infinity, layerMask);

            //Does the ray intersect any objects which are in the player layer.
            if ((hit.transform != null) && (hit.transform.gameObject.name.Equals("Unit(Clone)")))
            {
            }
            else
            {
                hit = Physics2D.Raycast(origin, Vector3.forward, Mathf.Infinity, ~layerMask);

                // Does the ray intersect any tile in the game board layer.
                if (hit.transform.gameObject.name.Equals("Tile(Clone)"))
                {
                    foreach (Player player in players)
                    {
                        foreach (Unit unit in player.team)
                        {
                            if (unit.isSelected == true)
                            {
                                unit.unselect();
                            }
                        }
                    }

                    Tile selectedTile = hit.transform.gameObject.GetComponent<Tile>();
                    if (selectedTile.modifier.modifierName.Equals("START"))
                    {
                        if (selectedTile.isTraversable)
                        {
                            ((Player)players[0]).createUnit();
                        }
                    }
                    else if (selectedTile.modifier.modifierName.Equals("GOAL"))
                    {
                        if (selectedTile.isTraversable)
                        {
                            ((Player)players[1]).createUnit();
                        }
                    }
                }
            }

            // What if you hit outside the gameboard?
        }
        // float horizontalMovement = Input.GetAxis("Horizontal");
        // float verticalMovement = Input.GetAxis("Vertical");
=======
        currentTile = currentGameBoard.board[(int)currentUnit.position.x, (int)currentUnit.position.y];

        // If eastern tile exists
        if (currentTile.GetComponent<Transform>().position.x < currentGameBoard.board.GetLength(0) - 1)
        {
            easternTile = currentGameBoard.board[(int)currentUnit.position.x + 1, (int)currentUnit.position.y];
        }
        else
        {
            easternTile = null;
        }

        // If western tile exists
        if (currentTile.GetComponent<Transform>().position.x > 0)
        {
            westernTile = currentGameBoard.board[(int)currentUnit.position.x - 1, (int)currentUnit.position.y];
        }
        else
        {
            westernTile = null;
        }

        // If northern tile exists
        if (currentTile.GetComponent<Transform>().position.y < currentGameBoard.board.GetLength(1) - 1)
        {
            northernTile = currentGameBoard.board[(int)currentUnit.position.x, (int)currentUnit.position.y + 1];
        }
        else
        {
            northernTile = null;
        }

        // If southern tile exists
        if (currentTile.GetComponent<Transform>().position.y > 0)
        {
            southernTile = currentGameBoard.board[(int)currentUnit.position.x, (int)currentUnit.position.y - 1];
        }
        else
        {
            southernTile = null;
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (currentUnit.isMoving == false)
        {
            if ((easternTile != null) && (easternTile.isTraversable == true) && (horizontalMovement > 0))
            {
                move(easternTile, "E");
            }
            else if ((westernTile != null) && (westernTile.isTraversable == true) && (horizontalMovement < 0))
            {
                move(westernTile, "W");
            }
            else if ((northernTile != null) && (northernTile.isTraversable == true) && (verticalMovement > 0))
            {
                move(northernTile, "N");
            }
            else if ((southernTile != null) && (southernTile.isTraversable == true) && (verticalMovement < 0))
            {
                move(southernTile, "S");
            }
            else
            {
                // Blink selected unit

            }
        }
        else
        {
            if (currentTile.modifier.modifierName.Equals("GOAL"))
            {
                Destroy(currentUnit.GetComponent<SpriteRenderer>());
                Destroy(currentUnit);
                score += 1;
            }
            else if ((currentUnit.direction.Equals("E")) && ((easternTile != null) && (easternTile.isTraversable)))
            {
                move(easternTile, "E");
            }
            else if ((currentUnit.direction.Equals("W")) && ((westernTile != null) && (westernTile.isTraversable)))
            {
                move(westernTile, "W");
            }
            else if ((currentUnit.direction.Equals("N")) && ((northernTile != null) && (northernTile.isTraversable)))
            {
                move(northernTile, "N");
            }
            else if ((currentUnit.direction.Equals("S")) && ((southernTile != null) && (southernTile.isTraversable)))
            {
                move(southernTile, "S");
            }
            else
            {
                currentUnit.isMoving = false;
                currentTile.isTraversable = false;
            }
        }
    }

    private void move(Tile tileToMoveTo, string direction)
    {
        currentUnit.isMoving = true;
        currentUnit.direction = direction;
        currentTile.unit = null;
        currentUnit.position = tileToMoveTo.GetComponent<Transform>().position;
        currentUnit.GetComponent<Transform>().position = currentUnit.position;
        tileToMoveTo.unit = currentUnit;
        currentTile.isTraversable = true;
>>>>>>> 6d940a05425dd8e3018fd3826b71c968b53557b6
    }
}
