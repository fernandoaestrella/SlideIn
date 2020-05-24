using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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


    // private float nextActionTime = 0.0f;
    // public float period = 0.6f;

    void Start()
    {
         if (GameObject.Find("P2").name.Equals(playerName) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine("RandomAI");
        }
    }

    void Update()
    {
        // if (GameObject.Find("P2").name.Equals(playerName))
        // {
        //     if (Time.time > nextActionTime)
        //     {
        //         nextActionTime = Time.time + period;
        //     }
        // }
    }

    public IEnumerator RandomAI()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            
        }
    }
}
