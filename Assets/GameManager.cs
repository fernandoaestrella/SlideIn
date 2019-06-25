using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameBoard gameBoard;
    //public ArrayList playerUnits = new ArrayList();
    public Tile tile;
    public Unit unit;
    Tile currentTile;
    Tile easternTile;
    Tile westernTile;
    Tile northernTile;
    Tile southernTile;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        //GameBoard currentGameBoard = new GameBoard();
        //currentGameBoard = Instantiate(gameBoard);
        gameBoard.board = new Tile[15, 9];

        createBoard();

        // Add traversable tiles
        for (int i = 0; i < gameBoard.board.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.board.GetLength(1); j++)
            {
                Tile currentTile = new Tile();
                currentTile = Instantiate(tile);
                currentTile.isTraversable = true;
                currentTile.GetComponent<Transform>().position = new Vector3(i, j, 0);
                currentTile.modifier = new Modifier();
                currentTile.modifier.modifierName = "TILE";

                if ((i + j) % 2 == 0)
                {
                    currentTile.GetComponent<SpriteRenderer>().color = Color.gray;
                }

                // Makes top and bottom row untraversable
                if ((j == 0) || (j == gameBoard.board.GetLength(1) - 1))
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

                gameBoard.board[i, j] = currentTile;

                Debug.Log(i + ", " + j);
            }
        }

        unit = Instantiate(unit);
        unit.position = gameBoard.board[1, 1].GetComponent<Transform>().position;
        unit.GetComponent<Transform>().position = unit.position;
        gameBoard.board[1, 1].unit = unit;
    }

    private void createBoard()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTile = gameBoard.board[(int)unit.position.x, (int)unit.position.y];

        // If eastern tile exists
        if (currentTile.GetComponent<Transform>().position.x < gameBoard.board.GetLength(0) - 1)
        {
            easternTile = gameBoard.board[(int)unit.position.x + 1, (int)unit.position.y];
        }
        else
        {
            easternTile = null;
        }

        // If western tile exists
        if (currentTile.GetComponent<Transform>().position.x > 0)
        {
            westernTile = gameBoard.board[(int)unit.position.x - 1, (int)unit.position.y];
        }
        else
        {
            westernTile = null;
        }

        // If northern tile exists
        if (currentTile.GetComponent<Transform>().position.y < gameBoard.board.GetLength(1) - 1)
        {
            northernTile = gameBoard.board[(int)unit.position.x, (int)unit.position.y + 1];
        }
        else
        {
            northernTile = null;
        }

        // If southern tile exists
        if (currentTile.GetComponent<Transform>().position.y > 0)
        {
            southernTile = gameBoard.board[(int)unit.position.x, (int)unit.position.y - 1];
        }
        else
        {
            southernTile = null;
        }

        if (unit.moving == false)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            if (horizontalMovement > 0)
            {
                if ((easternTile != null) && (easternTile.isTraversable == true))
                {
                    moveEast();
                }
            }
            else if (horizontalMovement < 0)
            {
                if ((westernTile != null) && (westernTile.isTraversable == true))
                {
                    moveWest();
                }
            }
            else if (verticalMovement > 0)
            {
                if ((northernTile != null) && (northernTile.isTraversable == true))
                {
                    moveNorth();
                }
            }
            else if (verticalMovement < 0)
            {
                if ((southernTile != null) && (southernTile.isTraversable == true))
                {
                    moveSouth();
                }
            }
        }
        else
        {
            if (unit.moving)
            {
                if (currentTile.modifier.modifierName.Equals("GOAL"))
                {
                    Destroy(unit);
                    score += 1;
                }
                else
                if ((unit.direction.Equals("E")) && ((easternTile != null) && (easternTile.isTraversable)))
                {
                    moveEast();
                }
                else if ((unit.direction.Equals("W")) && ((westernTile != null) && (westernTile.isTraversable)))
                {
                    moveWest();
                }
                else if ((unit.direction.Equals("N")) && ((northernTile != null) && (northernTile.isTraversable)))
                {
                    moveNorth();
                }
                else if ((unit.direction.Equals("S")) && ((southernTile != null) && (southernTile.isTraversable)))
                {
                    moveSouth();
                }
                else
                {
                    unit.moving = false;
                    currentTile.isTraversable = false;
                }
            }
        }
    }

    private void moveSouth()
    {
        unit.moving = true;
        unit.direction = "S";
        currentTile.unit = null;
        unit.position = southernTile.GetComponent<Transform>().position;
        unit.GetComponent<Transform>().position = unit.position;
        southernTile.unit = unit;
        currentTile.isTraversable = true;
    }

    private void moveNorth()
    {
        unit.moving = true;
        unit.direction = "N";
        currentTile.unit = null;
        unit.position = northernTile.GetComponent<Transform>().position;
        unit.GetComponent<Transform>().position = unit.position;
        northernTile.unit = unit;
        currentTile.isTraversable = true;
    }

    private void moveWest()
    {
        unit.moving = true;
        unit.direction = "W";
        currentTile.unit = null;
        unit.position = westernTile.GetComponent<Transform>().position;
        unit.GetComponent<Transform>().position = unit.position;
        westernTile.unit = unit;
        currentTile.isTraversable = true;
    }

    private void moveEast()
    {
        unit.moving = true;
        unit.direction = "E";
        currentTile.unit = null;
        unit.position = easternTile.GetComponent<Transform>().position;
        unit.GetComponent<Transform>().position = unit.position;
        easternTile.unit = unit;
        currentTile.isTraversable = true;
    }

    private void move(Tile tileToMoveTo)
    {
        
    }
}
