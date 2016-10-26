using UnityEngine;
using System.Collections;
/// <summary>
/// 游戏状态监听器接口
/// </summary>
public interface GameStateChangeListener {
    /// <summary>
    /// 游戏状态改变
    /// </summary>
    /// <param name="state">改变后的状态</param>
    void GameStateChange(Util.GameState state);
}
