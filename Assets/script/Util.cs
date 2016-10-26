using UnityEngine;
using System.Collections;


public class Util : MonoBehaviour
{

    //游戏模式
    public const string GAME_TYPE = "game_type";

    //无尽模式
    public const int GAME_TYPE_INFINTE = 1;
    //冒险模式
    public const int GAME_TYPE_ADV = 2;

    //无尽模式难度
    public const string INFINETE_LEVEL = "infinete.level";
    public const int INFINETE_DEFULT_LEVEL = 2;

    //无尽模式关卡
    public const string INFINETE_N = "infinete.n";
    public const int INFINETE_DEFULT_N = 5;

    public const int SCENES_START_GAME = 0;
    public const int SCENES_MODE_CHOOSE = 1;
    public const int SCENES_GAME = 2;

 

    public enum Direction { none = 0, up = 1, down = 2, left = 3, right = 4 };
    public enum GameState {undefined=-1,gaming=0,gameOver=1,showRoad=2,pause=3};
    public static Direction getDirection(Cube start, Cube end)
    {
        int startX, startY, endX, endY;
        startX = start.x;
        startY = start.y;
        endX = end.x;
        endY = end.y;

        Direction d = Direction.none;

        if(startX==endX-1){
            d = Direction.down;
        }
        else if(startX==endX+1){
            d = Direction.up;

        }else if(startY==endY-1){
            d = Direction.right;

        }else if(startY==endY+1){
            d = Direction.left;

        }

        return d;
    }
    /// <summary>
    /// 根据N获取地图初始路径长度
    /// </summary>
    /// <param name="N">地图边长</param>
    /// <returns>等级0的时候对应的路径长度</returns>
    public static int getStartLenByN(int N)
    {
        int startLen = 2 * N - 1;
        return startLen+(startLen/4)*2-1;
    }
    /// <summary>
    /// 调试用的函数,用来在不是u3d对象中输出
    /// </summary>
    /// <param name="s">输出的内容</param>
    public static void Printf(string s)
    {
        print(s);
    }

}


