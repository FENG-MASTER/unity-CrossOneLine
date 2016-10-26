using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class _Point {
   

    public int x;
    public int y;
    public List<Util.Direction> directionList = new List<Util.Direction>();

    public _Point(int x, int y, Util.Direction d = Util.Direction.none)
    {

        this.x = x;
        this.y = y;

        directionList.Add(Util.Direction.down);
        directionList.Add(Util.Direction.up);
        directionList.Add(Util.Direction.right);
        directionList.Add(Util.Direction.left);
        if (d != Util.Direction.none)
        {
            directionList.Remove(getOppoDirection(d));
        }
    }

    public override bool Equals(object obj)
    {
        return ((_Point)obj).x == this.x && ((_Point)obj).y == this.y;
    }

    public Util.Direction getNextDirection()
    {
        if (directionList.Count == 0)
        {
            return Util.Direction.none;
        }

        int r = Random.Range(0, directionList.Count);
        Util.Direction d = directionList[r];
        directionList.RemoveAt(r);
        return d;
    }

    public static Util.Direction getOppoDirection(Util.Direction d)
    {
        Util.Direction oppo = Util.Direction.none;
        switch (d)
        {
            case Util.Direction.up:
                oppo = Util.Direction.down;
                break;
            case Util.Direction.down:
                oppo = Util.Direction.up;
                break;
            case Util.Direction.left:
                oppo = Util.Direction.right;
                break;
            case Util.Direction.right:
                oppo = Util.Direction.left;
                break;
            default:
                break;

        }
        return oppo;
    }
	
}
