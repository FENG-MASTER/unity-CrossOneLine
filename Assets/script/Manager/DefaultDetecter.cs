using UnityEngine;
using System.Collections;
/// <summary>
/// 默认的游戏结束检测器
/// </summary>
public class DefaultDetecter : GameDetecter {




    public override bool checkMissionCompleted(Cube[,] arr)
    {
        return allCubesClear(arr);
    }


    /// <summary>
    /// 检测二维数组中的所有的方块是否都已经全部为0,如果全部是0,那么游戏结束
    /// </summary>
    /// <param name="arr">需要检测的方块数组</param>
    /// <returns>游戏是否结束</returns>
    private bool allCubesClear(Cube[,] arr)
    {
        int n1=arr.GetLength(0);
        int n2=arr.GetLength(1);
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                if (arr[i, j].hasCrossTime())
                {
                    return false;
                }
            }
        }
        

        return true;
    }
}
