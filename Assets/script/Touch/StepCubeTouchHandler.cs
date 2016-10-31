using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 触摸处理器--步数
/// 必须达到相应的步数要求才能点击该方块并生效
/// </summary>
public class StepCubeTouchHandler : CubeTouchHandler,TouchController.TouchListener {
    private List<int> stepRequest;//要求点击该方块的时候需要达到的步数
    private bool isTouched = false;
    private Cube cube;
    private int touchTime = 0;

    public StepCubeTouchHandler(Cube cb)
    {
        stepRequest = cb.getSteps();
        cube = cb;
        TouchController.getInstance().setTouchListener(this);
    }


    public void OnStartTouch(Cube b)
    {
        if (TouchController.startTouch == false)
        {
            return;
        }
        if (b.getNeedCrossTime() != 0)
        {
            if (TouchController.getInstance().canTouch(b))
            {
                if (TouchController.getInstance().setTouchCube(b))
                {
                    b.crossOneTime();
                    touchTime++;
                }

            }
        }
    }

    public void Ontouch(Cube b)
    {
        stepRequest.ForEach(delegate(int i) { Util.Printf(i+""); });
        Util.Printf(" step:"+TouchController.getInstance().getStep());
        if (TouchController.startTouch == false)
        {
            return;
        }
        if (isTouched == false)
        {
            if (b.getNeedCrossTime() != 0 && TouchController.getInstance().getStep() + 1 == stepRequest[0])
            {
                if (TouchController.getInstance().canTouch(b))
                {
                    if (TouchController.getInstance().setTouchCube(b))
                    {
                        b.crossOneTime();
                        isTouched = true;
                        touchTime++;
                    }
                }
            }
        }
        else {

            if (b.getNeedCrossTime() != 0)
            {
                if (TouchController.getInstance().canTouch(b))
                {
                    if (TouchController.getInstance().setTouchCube(b))
                    {
                        b.crossOneTime();
                        touchTime++;
                    }
                }
            }
        
        }

   
    }

    public void OnRelaseTouch(Cube b)
    {
        isTouched = false;
        TouchController.getInstance().OnRelaseTouch(b);
    }




    public void Update()
    {
        
        if(touchTime<stepRequest.Count){
            cube.showRequestNum(stepRequest[0]);
        }
        else
        {
            cube.showRequestNum(0);
        }

    }

    public void OnRelase()
    {
        isTouched = false;
        touchTime = 0;
    }

    public void Init(Cube cb)
    {
        
    }
}
