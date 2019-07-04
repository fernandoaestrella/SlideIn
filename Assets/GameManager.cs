using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameBoard currentGameBoard;
    public Tile tile;
    public Unit unit;
    public Unit selectedUnit;
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
        matchDuration = 4f;

        createBoard();

        players = new ArrayList(16); // Initial size set to avoid some overflow cycles (wherein inserting an element in the array exceeds its capacity and activates a script that creates a new, bigger array)
        players.Insert(0, new Player());
        players.Insert(1, new Player());

        ((Player)players[0]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles
        ((Player)players[1]).team = new ArrayList(16); // Initial size set to avoid some overflow cycles

        ((Player)players[0]).startX = 1;
        ((Player)players[0]).startY = 4;

        ((Player)players[1]).startX = 11;
        ((Player)players[1]).startY = 4;

        ((Player)players[0]).unitColor = new Color(0.5f, 0.98f, 0.89f, 1);
        ((Player)players[1]).unitColor = new Color(1.0f, 0.4f, 0.8f, 1);
    }

    private Unit createUnit(Player player)
    {
        Unit newUnit = Instantiate(unit);
        // Tell unit which position it holds
        newUnit.position = currentGameBoard.board[player.startX, player.startY].GetComponent<Transform>().position;
        // Move unit to its position
        newUnit.GetComponent<Transform>().position = newUnit.position;
        // Tell tile which unit it holds
        currentGameBoard.board[player.startX, player.startY].unit = newUnit;
        // Makes that tile untraversable
        currentGameBoard.board[player.startX, player.startY].isTraversable = false;
        newUnit.GetComponent<SpriteRenderer>().color = player.unitColor;
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

                // Set the start
                if ((i == 1) && (j == 4))
                {
                    currentTile.modifier.modifierName = "START";
                    currentTile.GetComponent<SpriteRenderer>().color = Color.blue;
                }

                // Set the goal
                if ((i == 11) && (j == 4))
                {
                    currentTile.modifier.modifierName = "GOAL";
                    currentTile.GetComponent<SpriteRenderer>().color = Color.red;
                }

                // Save the tile in the gameboard
                currentGameBoard.board[i, j] = currentTile;

                Debug.Log(i + ", " + j);
            }
        }
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

        if (selectedUnit != null)
        {
            //((Player)players[0]).team.Add(createUnit());
            currentTile = currentGameBoard.board[(int)selectedUnit.position.x, (int)selectedUnit.position.y];

            // If eastern tile exists
            if (currentTile.GetComponent<Transform>().position.x < currentGameBoard.board.GetLength(0) - 1)
            {
                easternTile = currentGameBoard.board[(int)selectedUnit.position.x + 1, (int)selectedUnit.position.y];
            }
            else
            {
                easternTile = null;
            }

            // If western tile exists
            if (currentTile.GetComponent<Transform>().position.x > 0)
            {
                westernTile = currentGameBoard.board[(int)selectedUnit.position.x - 1, (int)selectedUnit.position.y];
            }
            else
            {
                westernTile = null;
            }

            // If northern tile exists
            if (currentTile.GetComponent<Transform>().position.y < currentGameBoard.board.GetLength(1) - 1)
            {
                northernTile = currentGameBoard.board[(int)selectedUnit.position.x, (int)selectedUnit.position.y + 1];
            }
            else
            {
                northernTile = null;
            }

            // If southern tile exists
            if (currentTile.GetComponent<Transform>().position.y > 0)
            {
                southernTile = currentGameBoard.board[(int)selectedUnit.position.x, (int)selectedUnit.position.y - 1];
            }
            else
            {
                southernTile = null;
            }

            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            if (selectedUnit.isMoving == false)
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
                        ((Player) players[0]).score += 1;
                    }
                }
                else if (currentTile.modifier.modifierName.Equals("START"))
                {
                    if (((Player)players[1]).team.Contains(selectedUnit))
                    {
                        Destroy(selectedUnit.GetComponent<SpriteRenderer>());
                        Destroy(selectedUnit.gameObject);
                        ((Player)players[1]).score += 1;
                    }
                }

                if ((selectedUnit.direction.Equals("E")) && ((easternTile != null) && (easternTile.isTraversable)))
                {
                    move(easternTile, "E");
                }
                else if ((selectedUnit.direction.Equals("W")) && ((westernTile != null) && (westernTile.isTraversable)))
                {
                    move(westernTile, "W");
                }
                else if ((selectedUnit.direction.Equals("N")) && ((northernTile != null) && (northernTile.isTraversable)))
                {
                    move(northernTile, "N");
                }
                else if ((selectedUnit.direction.Equals("S")) && ((southernTile != null) && (southernTile.isTraversable)))
                {
                    move(southernTile, "S");
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
    }
}
