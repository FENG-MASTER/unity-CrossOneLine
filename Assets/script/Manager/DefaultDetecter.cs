using UnityEngine;
using System.Collections;

public class DefaultDetecter : GameDetecter {

    


    public bool isMissionCompleted(Cube[,] arr)
    {
        if(arr==null){
            return false;
        }
        return allCubesClear(arr);
    }


    //检测二维数组中的所有的方块是否都已经全部为0
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
