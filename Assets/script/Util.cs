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
    public static int getStartLenByN(_Point s,_Point e,int N)
    {

        int startLen  = Mathf.Abs(s.x - e.x) + Mathf.Abs(s.y - e.y) + 1;
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

    /// <summary>
    /// 随机获取指定范围内两个不重复的点
    /// </summary>
    /// <param name="n">范围</param>
    /// <returns>两个点</returns>
    public static _Point[] getRandomStartAndEndPoint(int n, int requestNum, bool fixedStart=true)
    {
        if(requestNum==0){
            return new _Point[0];
        }
        int[] ints = getRandomInts(n);

        _Point[] ps = new _Point[requestNum];
        for (int i = 0; i < requestNum; i++)
        {
            ps[i] = new _Point(0,0);
        }

        for (int i = 0; i < requestNum; i++)
        {
            ps[i].x = ints[i];
        }

        ints = getRandomInts(n);

        for (int i = 0; i < requestNum; i++)
        {
            ps[i].y = ints[i];
        }

        if(fixedStart){
            ps[0].x = 0;
            ps[0].y = 0;
        }
        
        return ps;

    }

    private static int[] getRandomInts(int n)
    {
        int[] ints = new int[n];

        for (int i = 0; i < n; i++)
        {
            ints[i] = i;
        }

        int temp;
        int tempN;
        for (int i = 0; i < n; i++)
        {
            tempN = Random.Range(0, n);
            temp = ints[i];
            ints[i] = ints[tempN];
            ints[tempN] = temp;
        }

        return ints;

    }

}


