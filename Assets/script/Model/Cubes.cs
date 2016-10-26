using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cubes : MonoBehaviour,GameStateChangeListener {

    public Cube[,] cubesList;//存储所有方块的二维数组
    private List<Cube> activityCubeList=new List<Cube>();//存储活动的方块数组, 0号是当前按下的方块,剩下的是可以按的方块

    private GameObject cubesObjList;
    public static Cubes instance;
    private int N=0;

    private GameDetecter detector;
 

    private RoadMaker roadMaker;

    void Awake()
    {
        instance = this;
        roadMaker = new GeneralRoadMaker();
        detector = new DefaultDetecter();
    }



    /// <summary>
    /// 恢复所有方块的状态(已经有数)
    /// </summary>
    public void restore()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                cubesList[i, j].restore();
            }
        }
    }




    public void Init()
    {

        InitCube(Res.instance.cubeSpriteList[0].texture.width, Res.instance.cubeSpriteList[0].texture.height);
        
        cubesList=new Cube[N,N];
        for (int i=0; i < N;i++ )
        {
            for (int j = 0; j < N; j++)
            {
                cubesList[i, j] = GameObject.Instantiate<GameObject>(Res.instance.cubePrefab).GetComponent<Cube>();
                cubesList[i, j].gameObject.transform.SetParent(GameObject.Find("CubesPlane").transform);
                cubesList[i, j].Init(i,j);
            }
        }

        MainControler.instance.AddGameStateChangeListener(this);
       
    }
    /// <summary>
    /// 指定方块的数字减少N,这个函数应该是在玩家点击了某方块后执行的方法,也可以用于显示路径
    /// </summary>
    /// <param name="i">方块x坐标</param>
    /// <param name="j">方块y坐标</param>
    /// <param name="n">减少多少</param>
    public void crossTime(int i,int j,int n)
    {
        cubesList[i, j].crossOneTime(n);
    }
    /// <summary>
    /// 清除所有方块,清空,包括显示
    /// </summary>
    public void ClearAll()
    {

        ClearData();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Destroy(cubesList[i, j].gameObject);

            }
        }
    }

    /*
     * 清空数据用的函数
     * 
     **/
    public void ClearData()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                cubesList[i, j].Init(i,j);
            }
        }
    }

    public void NewGame(_Point s,_Point e,int N,int level,int requestLeftNum)
    {//TODO:requestLeftNum这个功能没有实现
        if(this.N!=N){
            ClearAll();
            this.N = N;
            Init();
        }

        ClearData();

        List<_Point> rs = RoadManager.instance.makeRoad(new _Point(0, 0), new _Point(N - 1, N - 1), N, level);

        foreach (_Point p in rs)
        {
            cubesList[p.x,p.y].AddCrossTime(1);
        }
    }

    private void InitCube(float width,float height)
    {

        //计算每个方块的边长信息
        Cube.width = Screen.width / 100.0f * 0.9f / Cubes.instance.N;
        Cube.height = Cube.width;

        //居中显示
        Cube.init_x = Camera.main.transform.position.x - Screen.width / 100.0f / 2.0f + Cube.width / 2f + Screen.width / 100.0f * 0.05f;
        Cube.init_y = Camera.main.transform.position.y + Screen.height / 100.0f / 2.0f - Cube.height / 2f -Screen.height/100.0f*0.1f;

        Cube.scale = Cube.width / (width/100f);//设置缩放比例

        
    }

    public List<Cube> getAroundCubes(Cube c)
    {
        //TODO: getAroundCubes 未完成
        List<Cube> aroundList = new List<Cube>();

        int x = c.x;
        int y = c.y;

        if (x <= 0)
        {        
             aroundList.Add(cubesList[y, x + 1]);
        }
        else if (x >= N - 1)
        {

            aroundList.Add(cubesList[y, x - 1]);
        }
        else
        {

            aroundList.Add(cubesList[y, x + 1]);
            aroundList.Add(cubesList[y, x - 1]);

        }

        if (y <= 0)
        {
            aroundList.Add(cubesList[y + 1, x]);

        }
        else if (y >= N - 1)
        {
            aroundList.Add(cubesList[y - 1, x]);

        }
        else
        {
            aroundList.Add(cubesList[y + 1, x]);
            aroundList.Add(cubesList[y - 1, x]);

        }

        return aroundList;
    }

    private void setCubesTouchable(bool able)
    {

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                cubesList[i,j].gameObject.GetComponent<BoxCollider>().enabled = able;
            }
        }
 
    }


    public void GameStateChange(Util.GameState state)
    {
        if (state != Util.GameState.gaming)
        {
            setCubesTouchable(false);
        }
        else
        {
            setCubesTouchable(true);
        }
    }
}
