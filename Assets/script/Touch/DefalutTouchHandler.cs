using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefalutTouchHandler : TouchHandler {

    private List<Cube> activityCubeList =new List<Cube>();
    private bool startTouch = false;
    private Cube startCube;
    private Cube endCube;

    public DefalutTouchHandler()
    {
        startCube = null;
        endCube = null;
    }

    public DefalutTouchHandler(Cube s,Cube e)
    {
        startCube = s;
        endCube = e;
    }

    public override void OnStartTouch(Cube b)
    {
        clear();

        if (startCube != null && !b.Equals(startCube))
        {
            return;
        }

        activityCubeList.Add(b);
        b.crossOneTime();
        addAroundCubes(b);

        startTouch = true;
        
        
    }

    public override void Ontouch(Cube b)
    {

        if(startTouch==false){
            return;
        }

        if (activityCubeList.Count == 0)
        {
            //如果活动list中什么都没有,那证明是第一次按下,也就是刚刚按下起点

            activityCubeList.Add(b);
            b.crossOneTime();
            addAroundCubes(b);
          
        }
        else if (activityCubeList.Exists(
            delegate(Cube a)
            {
                return a.Equals(b);
            }
            ))
        {

            Cube lastPressCube = activityCubeList[0];
            if (lastPressCube.Equals(b))
            {
                return;
            }

            activityCubeList.Clear();

            activityCubeList.Add(b);
            b.crossOneTime();
            addAroundCubes(b);
            activityCubeList.Remove(lastPressCube);//除去刚刚来的那个方向的方块(不允许回头)
      
        }


    }

    public override void OnRelaseTouch(Cube b)
    {
        clear();
        Cubes.instance.restore();
    }


    private void addAroundCubes(Cube c)
    {
        List<Cube> list = Cubes.instance.getAroundCubes(c);
        foreach(Cube cb in list){
            if(cb.hasCrossTime()){
                activityCubeList.Add(cb);
            }
        }

    }

    private void clear()
    {

        activityCubeList.Clear();
        startTouch = false;
    }


}
