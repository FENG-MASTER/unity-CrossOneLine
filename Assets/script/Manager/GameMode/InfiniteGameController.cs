using UnityEngine;
using System.Collections;

/// <summary>
/// 无尽模式
/// </summary>
public class InfiniteGameController :BaseGameController {

    //当前难度,其实代表了在最小距离上增加的路线的长度,这个参数决定了路线的曲折情况
    private int level=2;

    //当前关卡,关卡其实代表了生成正方形的边长
    private int n;

    //游戏结束检测器
    private GameDetecter detector;

    private UILabel timeLabel;

    private GameTimer.Timer timer;

    private object[] parmsForGameEnd;

    private UILabel remainStepLabel;

    public void Init()
    {
        //初始化关卡信息
        level = PlayerPrefs.GetInt(Util.INFINETE_LEVEL, Util.INFINETE_DEFULT_LEVEL);
        n = PlayerPrefs.GetInt(Util.INFINETE_N, Util.INFINETE_DEFULT_N);
        detector = new DefaultDetecter();
        timer = new GameTimer.Timer();
        GameTimer.instance.Add(timer);
        timeLabel = GameObject.Find("time").GetComponent<UILabel>();
    }


    public void StartGame()
    {
        MainControler.instance.SetGameState( Util.GameState.gaming);
        Res.instance.label_level.text = n+1-Util.INFINETE_DEFULT_N+"-"+level/2;
        timer.stop();
        timer.start();
        startGameByLevel(n, level,null,null,2);
        NextLevel();
    }

    public void PauseGame()
    {
        timer.pause();
    }

    public void BackToGame()
    {
        timer.start();
    }

    public void StopGame()
    {
        timer.stop();
        MainControler.instance.SetGameState(Util.GameState.gameOver);
        SaveGame(n,level);
    }

    public void Update()
    {
        timer.Run = delegate(double sec)
        {
            timeLabel.text = sec + "";
        };
        ///检测是否游戏结束
        if (detector.isMissionCompleted(parmsForGameEnd))
        {
            
            StopGame();
            StartGame();
        }
    }

    /// <summary>
    /// 显示答案
    /// </summary>
    public void ShowAnswer()
    {
        MainControler.instance.SetGameState(Util.GameState.showRoad);
        RoadManager.instance.showRoad();
    }

    private void startGameByLevel(int n, int level, _Point start = null, _Point end = null, int requestLeftNum = 0)
    {
        
        if (null == start || null == end)
        {
            _Point[] ps = Util.getRandomStartAndEndPoint(n,2);
            start = ps[0];
            end = ps[1];
        }
        if(requestLeftNum!=0){
            detector = new RemainStepDetecter();
            parmsForGameEnd=new object[1];
            parmsForGameEnd[0] = requestLeftNum;
        }

        Cubes.instance.NewGame(start, end, n, level, requestLeftNum);
    }



    /// <summary>
    /// 下一个关卡处理,包括了level和n的增加
    /// </summary>
    private void NextLevel()
    {
        level += 2;
        if(GetMaxLevelByN(n)<level){
            n++;
            level = 0;
        }
    }

    /// <summary>
    /// 获取n对应的最大level,超过这个level应该到新的n(关卡)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private int GetMaxLevelByN(int n) {
        return (int)(n*n*1.5);
    
    }
    /// <summary>
    /// 保存游戏进度
    /// </summary>
    /// <param name="n">当前关卡</param>
    /// <param name="level">当前难度</param>
    private void SaveGame(int n,int level)
    {
        PlayerPrefs.SetInt(Util.INFINETE_N,n);
        PlayerPrefs.SetInt(Util.INFINETE_LEVEL,level);
    }

   


  
}
