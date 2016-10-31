using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GameDetecter {



    /// <summary>
    /// 检测是否过关
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public bool isMissionCompleted(params object[] objects)
    {
        Cube[,] arr = Cubes.instance.cubesList;
        if (MainControler.instance.getGameState() != Util.GameState.gaming)
        {
            //检查下当前游戏状态,如果不是在游戏中,则永远返回否,即游戏没通关
            return false;
        }
        if (arr == null)
        {
            return false;
        }
        return checkMissionCompleted(objects);
    }

    public abstract bool checkMissionCompleted(params object[] objects);
	
}
