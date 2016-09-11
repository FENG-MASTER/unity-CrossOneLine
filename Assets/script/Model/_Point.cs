using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _Point {
    public enum Direction { none = 0, up = 1, down = 2, left = 3, right = 4 };

    public int x;
    public int y;
    public List<Direction> directionList = new List<Direction>();

    public _Point(int x, int y, Direction d = Direction.none)
    {

        this.x = x;
        this.y = y;

        directionList.Add(Direction.down);
        directionList.Add(Direction.up);
        directionList.Add(Direction.right);
        directionList.Add(Direction.left);
        if (d != Direction.none)
        {
            directionList.Remove(getOppoDirection(d));
        }
    }

    public override bool Equals(object obj)
    {
        return ((_Point)obj).x == this.x && ((_Point)obj).y == this.y;
    }

    public Direction getNextDirection()
    {
        if (directionList.Count == 0)
        {
            return Direction.none;
        }

        int r = Random.Range(0, directionList.Count);
        Direction d = directionList[r];
        directionList.RemoveAt(r);
        return d;
    }

    public static Direction getOppoDirection(Direction d)
    {
        Direction oppo = Direction.none;
        switch (d)
        {
            case Direction.up:
                oppo = Direction.down;
                break;
            case Direction.down:
                oppo = Direction.up;
                break;
            case Direction.left:
                oppo = Direction.right;
                break;
            case Direction.right:
                oppo = Direction.left;
                break;
            default:
                break;

        }
        return oppo;
    }
	
}
