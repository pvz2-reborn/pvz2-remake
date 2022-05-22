using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girds
{
    public Vector2 Point;// (0,1) (1,1)
    public Vector2 Position;

    public bool havePlant;

    public girds (Vector2 point, Vector2 position, bool havePlant) {
        Point = point;
        Position = position;
        havePlant = havePlant;
    }
}
