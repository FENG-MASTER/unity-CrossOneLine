using UnityEngine;
using System.Collections;

public class DefalutCubeTouchHandler : CubeTouchHandler {


    virtual public void OnStartTouch(Cube b)
    {
        if (TouchController.startTouch == false)
        {
            return;
        }
        if(b.hasCrossTime()){
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
        if (b.hasCrossTime())
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
}
