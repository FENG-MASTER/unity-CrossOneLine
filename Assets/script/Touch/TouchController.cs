using UnityEngine;
using System.Collections;
using System.Collections.Generic;   

public class TouchController : MonoBehaviour {

    private static TouchController instance;

    private List<Cube> touchAbleList=new List<Cube>();
    public static bool startTouch = false;//全局开始画线标记位

    public static TouchController getInstance()
    {//单例
        return instance;
    }

    void Awake()
    {
        ///单例
        instance = this;
    }



    /// <summary>
    /// 设置当前画线所碰到的方块,会更新允许下次触碰方块列表(不包括上次碰的方块),即不能回头
    /// </summary>
    /// <param name="cb">当前方块</param>
    /// <returns>是否添加成功</returns>
    public bool setTouchCube(Cube cb)
    {
        if(cb==null){
            return false;
        }

        if (touchAbleList.Count == 0)
        {
            touchAbleList.Add(cb);
            addAroundCubes(cb);
            startTouch = true;

        }
        else
        {
            Cube lastCube = touchAbleList[0];
            if(lastCube.Equals(cb)){
                return false;
            }
            touchAbleList.Clear();
            touchAbleList.Add(cb);
            addAroundCubes(cb);
            touchAbleList.Remove(lastCube);
        }
        return true;

    }
    /// <summary>
    /// 检测是否可以触碰
    /// </summary>
    /// <param name="cb">待检测方块</param>
    /// <returns>是否可以触碰</returns>
    public bool canTouch(Cube cb)
    {
        if(touchAbleList.Contains(cb)||touchAbleList.Count==0){
            return true;
        }else{
            return false;
        }
    }
    /// <summary>
    /// 用户放开鼠标调用函数,清空能点击方块列表和把全局标志位复位,并且调用Cubes的恢复显示
    /// </summary>
    /// <param name="cb"></param>
    public void OnRelaseTouch(Cube cb)
    {
        touchAbleList.Clear();
        startTouch = false;
        Cubes.instance.restore();
    }
    /// <summary>
    /// 添加指定方块四周的方块到能点击方块的列表(越界已经处理)
    /// </summary>
    /// <param name="c">指定方块</param>
    private void addAroundCubes(Cube c)
    {
        List<Cube> list = Cubes.instance.getAroundCubes(c);
        foreach (Cube cb in list)
        {
           touchAbleList.Add(cb);
        }

    }



}
