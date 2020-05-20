using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    private int x;
    private int y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    public override bool Equals(object obj)
    {
        return obj is Position position &&
               x == position.x &&
               y == position.y &&
               X == position.X &&
               Y == position.Y;
    }
}
