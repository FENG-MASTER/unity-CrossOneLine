using UnityEngine;
using System.Collections;

public class StartCubeTouchHandler : DefalutCubeTouchHandler {

    override public void OnStartTouch(Cube b) {
        TouchController.startTouch = true;
        base.OnStartTouch(b);
    }

  
}
