﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏主控制器
/// </summary>
public class MainControler : MonoBehaviour {


    private int level=0;//当前关卡
    public static MainControler instance;
    private Util.GameState gamestate=Util.GameState.undefined;//当前游戏状态
    private GameDetecter detector;//游戏结束检测器

    public GameObject pauseBackGround;

    //游戏状态监听列表
    private List<GameStateChangeListener> gameStateChangeListeners
        = new List<GameStateChangeListener>();
    

    private BaseGameController gameControl=new InfiniteGameController();
    void Awake()
    {//单例模式
        instance = this;
        detector = new DefaultDetecter();
    }

	void Start () {
        GameObject.Find("CubesPlane").gameObject.AddComponent<DefalutTouchHandler>();

        int mode = PlayerPrefs.GetInt(Util.GAME_TYPE,Util.GAME_TYPE_ADV);

        switch(mode){
            case Util.GAME_TYPE_INFINTE:
                gameControl=new InfiniteGameController();//无尽模式
                break;
            case Util.GAME_TYPE_ADV:
                gameControl = new AdventureGameController();//冒险模式
                break;
            default:
                 gameControl=new InfiniteGameController();//默认无尽模式
                break;
                
        }

        gameControl.Init();


	}
	

	void Update () {
        //当退出按下时
	    if(Input.GetKeyDown(KeyCode.Escape)){
            if(gamestate==Util.GameState.gaming){
                gamestate = Util.GameState.pause;
            }
        }

        gameControl.Update();

	}

    /// <summary>
    /// 游戏开始
    /// </summary>
    public void startGame()
    {
        gameControl.StartGame();

    }

    /// <summary>
    /// 结束关卡
    /// </summary>
    public void finishLevel()
    {
        gameControl.StopGame();

       
    }

    private void startGameByLevel(int n, int level, _Point start=null, _Point end=null, int requestLeftNum = 0)
    {

        if(null==start||null==end){
            start = new _Point(0,0);
            end = new _Point(n-1,n-1);
        }

        Cubes.instance.NewGame(start, end, n, level, requestLeftNum);
    }

    /// <summary>
    /// 显示路径答案
    /// </summary>
    public void showRoad()
    {
        gameControl.ShowAnswer();

    }

    /// <summary>
    /// 增加游戏状态监听器
    /// </summary>
    /// <param name="listener">监听器对象</param>
    public void AddGameStateChangeListener(GameStateChangeListener listener) {
        gameStateChangeListeners.Add(listener);
    }

    /// <summary>
    /// 移除游戏状态监听器
    /// </summary>
    /// <param name="listener">监听器对象</param>
    public void RemoveGameStateChangeListener(GameStateChangeListener listener)
    {
        gameStateChangeListeners.Remove(listener);
    }

    /// <summary>
    /// 游戏状态改变需要调用的函数,通知所有监听对象
    /// </summary>
    /// <param name="state"></param>
    private void GameStateChange(Util.GameState state)
    {
        gameStateChangeListeners.ForEach(delegate(GameStateChangeListener l) { l.GameStateChange(state); });
    }

    /// <summary>
    /// 设置游戏状态接口
    /// </summary>
    /// <param name="state"></param>
    public void SetGameState(Util.GameState state)
    {
        this.gamestate = state;
        GameStateChange(gamestate);
    }
    /// <summary>
    /// 获取游戏状态
    /// </summary>
    /// <returns></returns>
    public Util.GameState getGameState()
    {
        return gamestate;
    }

     
   

}

