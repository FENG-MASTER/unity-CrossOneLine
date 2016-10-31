using UnityEngine;
using System.Collections;
/// <summary>
/// 触摸处理器--开始
/// 当前方块必须是第一个按下的方块,就是必须作为起点
/// </summary>
public class StartCubeTouchHandler : DefalutCubeTouchHandler {

    override public void OnStartTouch(Cube b) {
        TouchController.startTouch = true;
        base.OnStartTouch(b);
    }

    public override void Init(Cube cb)
    {
        cb.gameObject.GetComponent<SpriteRenderer>().color=Color.red;
        
    }

  
}
