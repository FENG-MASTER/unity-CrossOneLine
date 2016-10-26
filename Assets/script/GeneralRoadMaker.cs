using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GeneralRoadMaker:RoadMaker
{

    private int N;

    private List<_Point> rs = new List<_Point>();

    public List<_Point> makeRoad(_Point start,_Point end,int n,int len)
    {
       
        N = n;
        rs = new List<_Point>();
        getRoad(start, end, rs, len);
        rs.Add(start);
        return rs;
    }



    bool getRoad(_Point start, _Point end, List<_Point> roads, int len)
    {
        if (start.x < 0 || start.y < 0 || end.x < 0 || end.y < 0 ||
            start.x >= N || start.y >= N || end.x >= N || end.y >= N ||
            (!start.Equals(end) && len == 0))
        {
            //越界情况
            return false;
        }
        else if (len == 0 && start.Equals(end))
        {
            //   roads.Add(start);    
            return true;
        }
        else
        {

            Util.Direction d;
            do
            {
                //生成方向
                d = start.getNextDirection();

                //生成新的起点然后继续回调生成路径

                _Point newP = null;
                switch (d)
                {
                    case Util.Direction.down:
                        newP = new _Point(start.x + 1, start.y, d);
                        break;
                    case Util.Direction.up:
                        newP = new _Point(start.x - 1, start.y, d);
                        break;
                    case Util.Direction.right:
                        newP = new _Point(start.x, start.y + 1, d);
                        break;
                    case Util.Direction.left:
                        newP = new _Point(start.x, start.y - 1, d);
                        break;
                    default:
                        return false;
                        break;

                }

                if (getRoad(newP, end, roads, len - 1))
                {
                    roads.Add(newP);
                    return true;
                }



            } while (d != Util.Direction.none);

            return false;




        }
    }
}


