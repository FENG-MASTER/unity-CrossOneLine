using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Test : MonoBehaviour {

    public class _Point{
       public enum Direction {none=0,up=1,down=2,left=3,right=4};
        
       public int x;
       public int y;
       public List<Direction> directionList=new List<Direction>();

        public _Point(int x,int y,Direction d=Direction.none)
        {
            
            this.x = x;
            this.y = y;

            directionList.Add(Direction.down);
            directionList.Add(Direction.up);
            directionList.Add(Direction.right);
            directionList.Add(Direction.left);
            if(d!=Direction.none){
                directionList.Remove(getOppoDirection(d));
            }
        }

        public override bool Equals(object obj)
        {
            return ((_Point)obj).x == this.x && ((_Point)obj).y == this.y;
        }

        public Direction getNextDirection()
        {
            if(directionList.Count==0){
                return Direction.none;
            }

            int r = Random.Range(0,directionList.Count);
            Direction d=directionList[r];
            directionList.RemoveAt(r);
            return d;
        }

        public static Direction getOppoDirection(Direction d)
        {
            Direction oppo=Direction.none;
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

    private int N = 4;

    private List<_Point> rs=new List<_Point>();

	// Use this for initialization
	void Start () {

        getRoad(new _Point(0,0),new _Point(3,3),rs,17);
        print("??????????????");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    bool getRoad(_Point start,_Point end,List<_Point> roads,int len)
    {
        if (start.x < 0 || start.y < 0 || end.x < 0 || end.y < 0 || 
            start.x >= N||start.y>=N||end.x>=N||end.y>=N||
            (!start.Equals(end)&&len==0))
        {
            //越界情况
            return false;
        }else if(len==0&&start.Equals(end)){
             //   roads.Add(start);    
                return true;
        }
        else
        {
           
             _Point.Direction d;
            do{
                //生成方向
               d = start.getNextDirection();

               //生成新的起点然后继续回调生成路径

               _Point newP = null;
               switch (d)
               {
                   case _Point.Direction.down:
                       newP = new _Point(start.x + 1, start.y,d);
                       break;
                   case _Point.Direction.up:
                       newP = new _Point(start.x - 1, start.y,d);
                       break;
                   case _Point.Direction.right:
                       newP = new _Point(start.x, start.y + 1,d);
                       break;
                   case _Point.Direction.left:
                       newP = new _Point(start.x, start.y - 1,d);
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
              

                
            }while(d!=_Point.Direction.none);

               return false;
            
          
           

        }
    }

}

