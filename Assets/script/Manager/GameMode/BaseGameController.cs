using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏控制器接口,用于实现不同游戏模式
/// </summary>
public interface BaseGameController{


    /// <summary>
    /// 初始化
    /// </summary>
  void Init();

    /// <summary>
    /// 游戏开始
    /// </summary>
   void StartGame();

    /// <summary>
    /// 游戏暂停
    /// </summary>
  void PauseGame();


    /// <summary>
    /// 游戏结束
    /// </summary>
   void StopGame();

    /// <summary>
    /// 游戏更新
    /// </summary>
   void Update();

    /// <summary>
    /// 显示答案
    /// </summary>
  void ShowAnswer();

 

	
}
