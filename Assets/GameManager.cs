using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


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
    Tile currentTile;
    Tile easternTile;
    Tile westernTile;
    Tile northernTile;
    Tile southernTile;
    public ScreenControl p1Control;
    int p1StartX = 1;
    int p1StartY = 5;
    int p2StartX = 11;
    int p2StartY = 3;

    public float startTime;
    public float elapsedTime;
    public float matchDuration;
    public GameObject matchFinishedCanvas;
    public GameObject inGameCanvas;

    // Start is called before the first frame update
    public void Start()
    {
        startTime = Time.time;
        elapsedTime = 0f;
        matchDuration = 40f;
        Time.timeScale = 1; // Unpauses the game

        createBoard();

        players = new ArrayList(16); // Initial size set to avoid some overflow cycles (wherein inserting an element in the array exceeds its capacity and activates a script that creates a new, bigger array)
        // players.Insert(0, new Player(this));
        // players.Insert(1, new Player(this));
        // Player p = new Player(this);
        // GameObject.Find("Player").GetComponent<Player>();
        Player p = Instantiate(player);
        p.name = "P1";
        p.PlayerName = "P1";
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.Find("Move East Button").GetComponent<ScreenControl>().player = p;
            GameObject.Find("Move West Button").GetComponent<ScreenControl>().player = p;
            GameObject.Find("Move North Button").GetComponent<ScreenControl>().player = p;
            GameObject.Find("Move South Button").GetComponent<ScreenControl>().player = p;
        }
        players.Insert(0, p);

        p = Instantiate(player);
        p.name = "P2";
        p.PlayerName = "P2";
        players.Insert(1, p);

        // Set team size
        ((Player)players[0]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles
        ((Player)players[1]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles

        // Set player 1 starting position
        ((Player)players[0]).startTile = currentGameBoard.board[p1StartX, p1StartY];
        ((Player)players[0]).goalTile = currentGameBoard.board[p2StartX, p2StartY];


        ((Player)players[1]).startTile = currentGameBoard.board[p2StartX, p2StartY];
        ((Player)players[1]).goalTile = currentGameBoard.board[p1StartX, p1StartY];


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

                // // Make top and bottom row untraversable
                // if ((j == 0) || (j == currentGameBoard.board.GetLength(1) - 1))
                // {
                //     currentTile.modifier.modifierName = "UNPASSABLE";
                //     currentTile.isTraversable = false;
                //     currentTile.GetComponent<SpriteRenderer>().color = Color.black;
                // }

                // Save the tile in the gameboard
                currentTile.game = this;
                currentGameBoard.board[i, j] = currentTile;
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

        currentGameBoard.board[p1StartX, p1StartY].modifier.modifierName = "START";
        currentGameBoard.board[p1StartX, p1StartY].GetComponent<SpriteRenderer>().color = Color.blue;
        currentGameBoard.board[p2StartX, p2StartY].modifier.modifierName = "GOAL";
        currentGameBoard.board[p2StartX, p2StartY].GetComponent<SpriteRenderer>().color = Color.red;

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

        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;
        if (elapsedTime > matchDuration)
        {
            Time.timeScale = 0; // Pauses the game
            matchFinishedCanvas.SetActive(true);
            inGameCanvas.SetActive(false);

            // Stop controlling players
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     // int layerMask = 1 << 9;
        //     // Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //     // RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.forward, Mathf.Infinity, layerMask);

        //     //Does the ray intersect any objects which are in the player layer.
        //     // if ((hit.transform != null) && (hit.transform.gameObject.name.Equals("Unit(Clone)")))
        //     // {
        //     // }
        //     // else
        //     // {
        //     //     // hit = Physics2D.Raycast(origin, Vector3.forward, Mathf.Infinity, ~layerMask);

        //     //     // // Does the ray intersect any tile in the game board layer.
        //     //     // if (hit.transform.gameObject.name.Equals("Tile(Clone)"))
        //     //     // {
        //     //     //     // foreach (Player player in players)
        //     //     //     // {
        //     //     //     //     foreach (Unit unit in player.team)
        //     //     //     //     {
        //     //     //     //         if (unit.isSelected == true)
        //     //     //     //         {
        //     //     //     //             unit.unselect();
        //     //     //     //         }
        //     //     //     //     }
        //     //     //     // }

        //     //     //     // Tile selectedTile = hit.transform.gameObject.GetComponent<Tile>();
        //     //     //     // if (selectedTile.modifier.modifierName.Equals("START"))
        //     //     //     // {
        //     //     //     //     if (selectedTile.isTraversable)
        //     //     //     //     {
        //     //     //     //         ((Player)players[0]).createUnit();
        //     //     //     //     }
        //     //     //     // }
        //     //     //     // else if (selectedTile.modifier.modifierName.Equals("GOAL"))
        //     //     //     // {
        //     //     //     //     if (selectedTile.isTraversable)
        //     //     //     //     {
        //     //     //     //         ((Player)players[1]).createUnit();
        //     //     //     //     }
        //     //     //     // }
        //     //     // }
        //     // }

        //     // What if you hit outside the gameboard?
        // }
        // float horizontalMovement = Input.GetAxis("Horizontal");
        // float verticalMovement = Input.GetAxis("Vertical");
    }
}
