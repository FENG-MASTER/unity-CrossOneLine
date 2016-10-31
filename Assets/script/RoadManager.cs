using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour {

    public static RoadManager instance;

    private RoadMaker roadMaker=new GeneralRoadMaker();//路径生成器
    private List<_Point> roadlist;//路径列表

  
   
    /// <summary>
    /// 生成路径算法,委托路径生成对象去生成
    /// </summary>
    /// <param name="s">起始点</param>
    /// <param name="e">目标点</param>
    /// <param name="n">生成地图边长</param>
    /// <param name="level">难度等级</param>
    /// <returns></returns>
    public List<_Point> makeRoad(_Point s, _Point e, int n, int level)
    {
        roadlist = roadMaker.makeRoad(s, e, n, Util.getStartLenByN(s,e,n) + level);
    
        return roadlist;
    }

    public void showRoad()
    {
        if(showRoadNowNum>roadlist.Count-1){
            showRoadNowNum = 0;
            Cubes.instance.restore();
            MainControler.instance.SetGameState(Util.GameState.gaming);
        }
        else 
        {
            Cubes.instance.crossTime(roadlist[showRoadNowNum].x, roadlist[showRoadNowNum].y);
            showRoadNowNum++;
            Invoke("showRoad", 0.2f);//延迟执行函数,这里是为了简单的动画效果
        }


    }

    private static int showRoadNowNum = 0;//当前显示到的路径的长度
   

    void Awake()
    {
        instance = this;
        roadMaker = new GeneralRoadMaker();
    }

   


}
