using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameBoard currentGameBoard;
    public Tile tile;
    public Unit unit;
    public Unit selectedUnit;
    public ArrayList selectedUnits;
    public ArrayList movingUnits;

    public ArrayList players;
    Tile currentTile;
    Tile easternTile;
    Tile westernTile;
    Tile northernTile;
    Tile southernTile;
    bool blinkingOff;
    public float startTime;
    public float elapsedTime;
    public float matchDuration;
    public GameObject inGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        elapsedTime = 0f;
        matchDuration = 60f;

        createBoard();

        players = new ArrayList(16); // Initial size set to avoid some overflow cycles (wherein inserting an element in the array exceeds its capacity and activates a script that creates a new, bigger array)
        players.Insert(0, new Player());
        players.Insert(1, new Player());

        movingUnits = new ArrayList(16);
        // Set team size
        ((Player)players[0]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles
        ((Player)players[1]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles

        // Set player 1 starting position
        ((Player)players[0]).StartX = 1;
        ((Player)players[0]).StartY = 4;

        ((Player)players[1]).StartX = 11;
        ((Player)players[1]).StartY = 4;

        // Set team colors
        ((Player)players[0]).unitColor = new Color(0.5f, 0.98f, 0.89f, 1);
        ((Player)players[1]).unitColor = new Color(1.0f, 0.4f, 0.8f, 1);
    }

    private Unit createUnit(Player player)
    {
        Unit newUnit = Instantiate(unit);
        newUnit.game = this;
        // Tell unit which position it holds
        newUnit.position = currentGameBoard.board[player.StartX, player.StartY].GetComponent<Transform>().position;
        // Move unit to its position
        newUnit.GetComponent<Transform>().position = newUnit.position;
        // Tell tile which unit it holds
        currentGameBoard.board[player.StartX, player.StartY].unit = newUnit;
        // Makes that tile untraversable
        currentGameBoard.board[player.StartX, player.StartY].isTraversable = false;
        // Color unit
        newUnit.GetComponent<SpriteRenderer>().color = player.unitColor;
        // Add unit to player's team
        player.team.Add(newUnit);

        return newUnit;
    }

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

                // Make top and bottom row untraversable
                if ((j == 0) || (j == currentGameBoard.board.GetLength(1) - 1))
                {
                    currentTile.modifier.modifierName = "UNPASSABLE";
                    currentTile.isTraversable = false;
                    currentTile.GetComponent<SpriteRenderer>().color = Color.black;
                }

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

                Debug.Log(i + ", " + j);
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
        
    }

    // Update is called once per frame
    void Update()
    {
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
                // If there was a unit selected previously
                if (selectedUnit != null)
                {
                    Color tmp = selectedUnit.GetComponent<SpriteRenderer>().color;
                    tmp.a = 1;
                    selectedUnit.GetComponent<SpriteRenderer>().color = tmp;
                }
                selectedUnit = hit.transform.gameObject.GetComponent<Unit>();
            }
            else
            {
                hit = Physics2D.Raycast(origin, Vector3.forward, Mathf.Infinity, ~layerMask);

                // Does the ray intersect any tile in the game board layer.
                if (hit.transform.gameObject.name.Equals("Tile(Clone)"))
                {
                    if (selectedUnit != null)
                    {
                        Color tmp = selectedUnit.GetComponent<SpriteRenderer>().color;
                        tmp.a = 1;
                        selectedUnit.GetComponent<SpriteRenderer>().color = tmp;
                        selectedUnit = null;
                    }

                    Tile selectedTile = hit.transform.gameObject.GetComponent<Tile>();
                    if (selectedTile.modifier.modifierName.Equals("START"))
                    {
                        if (selectedTile.isTraversable)
                        {
                            createUnit((Player)players[0]);
                        }
                    }
                    else if (selectedTile.modifier.modifierName.Equals("GOAL"))
                    {
                        if (selectedTile.isTraversable)
                        {
                            createUnit((Player)players[1]);
                        }
                    }
                }
            }

            // What if you hit outside the gameboard?
        }

        foreach (Unit currentUnit in movingUnits)
        {
            
        }
        if (selectedUnit != null)
        {
            //((Player)players[0]).team.Add(createUnit());
            currentTile = currentGameBoard.board[(int)selectedUnit.position.x, (int)selectedUnit.position.y];

            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            if (selectedUnit.isMoving == false)
            {
                // if (!selectedUnit.move(horizontalMovement, verticalMovement, currentTile))
                // {
                //     // blink
                // }
                if ((currentTile.easternTile != null) && (currentTile.easternTile.isTraversable == true) && (horizontalMovement > 0))
                {
                    move(currentTile.easternTile, "E");
                }
                else if ((currentTile.westernTile != null) && (currentTile.westernTile.isTraversable == true) && (horizontalMovement < 0))
                {
                    move(currentTile.westernTile, "W");
                }
                else if ((currentTile.northernTile != null) && (currentTile.northernTile.isTraversable == true) && (verticalMovement > 0))
                {
                    move(currentTile.northernTile, "N");
                }
                else if ((currentTile.southernTile != null) && (currentTile.southernTile.isTraversable == true) && (verticalMovement < 0))
                {
                    move(currentTile.southernTile, "S");
                }
                else
                {
                    // Blink selected unit
                    Color tmp = selectedUnit.GetComponent<SpriteRenderer>().color;
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
                    selectedUnit.GetComponent<SpriteRenderer>().color = tmp;
                }
            }
            else
            {
                if (currentTile.modifier.modifierName.Equals("GOAL"))
                {
                    if (((Player)players[0]).team.Contains(selectedUnit))
                    {
                        Destroy(selectedUnit.GetComponent<SpriteRenderer>());
                        Destroy(selectedUnit.gameObject);
                        ((Player)players[0]).score += 1;
                        movingUnits.Remove(selectedUnit);
                    }
                }
                else if (currentTile.modifier.modifierName.Equals("START"))
                {
                    if (((Player)players[1]).team.Contains(selectedUnit))
                    {
                        Destroy(selectedUnit.GetComponent<SpriteRenderer>());
                        Destroy(selectedUnit.gameObject);
                        ((Player)players[1]).score += 1;
                        movingUnits.Remove(selectedUnit);
                    }
                }

                if ((selectedUnit.direction.Equals("E")) && ((currentTile.easternTile != null) && (currentTile.easternTile.isTraversable)))
                {
                    move(currentTile.easternTile, "E");
                    // movingUnits.Add(selectedUnit);
                }
                else if ((selectedUnit.direction.Equals("W")) && ((currentTile.westernTile != null) && (currentTile.westernTile.isTraversable)))
                {
                    move(currentTile.westernTile, "W");
                }
                else if ((selectedUnit.direction.Equals("N")) && ((currentTile.northernTile != null) && (currentTile.northernTile.isTraversable)))
                {
                    move(currentTile.northernTile, "N");
                }
                else if ((selectedUnit.direction.Equals("S")) && ((currentTile.southernTile != null) && (currentTile.southernTile.isTraversable)))
                {
                    move(currentTile.southernTile, "S");
                }
                else
                {
                    selectedUnit.direction = "";
                    selectedUnit.isMoving = false;
                    currentTile.isTraversable = false;
                }
            }
        }

    }

    void move(Tile tileToMoveTo, string direction)
    {
        selectedUnit.isMoving = true;
        selectedUnit.direction = direction;
        currentTile.unit = null;
        selectedUnit.position = tileToMoveTo.GetComponent<Transform>().position;
        selectedUnit.GetComponent<Transform>().position = selectedUnit.position;
        tileToMoveTo.unit = selectedUnit;
        currentTile.isTraversable = true;
        if (!movingUnits.Contains(selectedUnit))
        {
            // Debug.Log("contained!");
        }
    }
}
