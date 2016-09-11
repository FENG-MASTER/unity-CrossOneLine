using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefalutTouchHandler : TouchHandler {

    private List<Cube> activityCubeList;

    public DefalutTouchHandler()
    {
        activityCubeList = new List<Cube>();

    }


    public override void Ontouch(Cube b)
    {
        if (activityCubeList.Count == 0)
        {
            //如果活动list中什么都没有,那证明是第一次按下,也就是刚刚按下起点

            activityCubeList.Add(b);

            addAroundCubes(b);
          
        }
        else
        {

            Cube lastPressCube = activityCubeList[0];
            if (lastPressCube == b)
            {
                return ;
            }
           
            activityCubeList.Clear();

            activityCubeList.Add(b);
            
            addAroundCubes(b);
            activityCubeList.Remove(lastPressCube);//除去刚刚来的那个方向的方块(不允许回头)

        }




    }

    public override void OnRelase(Cube b)
    {
        throw new System.NotImplementedException();
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
}
