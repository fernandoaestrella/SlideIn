using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameBoard currentGameBoard;
    public Tile tile;
    public Unit currentUnit;
    Tile currentTile;
    Tile easternTile;
    Tile westernTile;
    Tile northernTile;
    Tile southernTile;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
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
            if ((westernTile != null) && (westernTile.isTraversable == true) && (horizontalMovement < 0))
            {
                move(westernTile, "W");
            }
            if ((northernTile != null) && (northernTile.isTraversable == true) && (verticalMovement > 0))
            {
                move(northernTile, "N");
            }
            if ((southernTile != null) && (southernTile.isTraversable == true) && (verticalMovement < 0))
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
    }
}
