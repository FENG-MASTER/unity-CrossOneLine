using UnityEngine;
using System.Collections;

public interface CubeTouchHandler  {


    /// <summary>
    /// 玩家开始触碰
    /// </summary>
    /// <param name="b">玩家点击的方块</param>
    void OnStartTouch(Cube b);
    /// <summary>
    /// 玩家触碰的时候
    /// </summary>
    /// <param name="b">触碰到的方块</param>
    void Ontouch(Cube b);
    /// <summary>
    /// 玩家不再触碰
    /// </summary>
    /// <param name="b">最后触碰到的方块</param>
    void OnRelaseTouch(Cube b);

}
