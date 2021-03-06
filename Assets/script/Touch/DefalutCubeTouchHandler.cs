﻿using UnityEngine;
using System.Collections;

public class DefalutCubeTouchHandler : CubeTouchHandler {


    virtual public void OnStartTouch(Cube b)
    {
        if (TouchController.startTouch == false)
        {
            return;
        }
        if(b.getNeedCrossTime()!=0){
            if (TouchController.getInstance().canTouch(b))
            {
                if (TouchController.getInstance().setTouchCube(b))
                {
                    b.crossOneTime();
                }

            }
        }
        
    }

    virtual public void Ontouch(Cube b)
    {
        if(TouchController.startTouch==false){
            return;
        }
        if (b.getNeedCrossTime() != 0)
        {
            if (TouchController.getInstance().canTouch(b))
            {
                if (TouchController.getInstance().setTouchCube(b))
                {
                    b.crossOneTime();

                }
            }
        }
    }

    virtual public void OnRelaseTouch(Cube b)
    {
        TouchController.getInstance().OnRelaseTouch(b);
    }


    public void Update()
    {
        
    }

    virtual public void Init(Cube cb)
    {
        
    }
}
