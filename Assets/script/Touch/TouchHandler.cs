using UnityEngine;
using System.Collections;

public abstract class TouchHandler : MonoBehaviour {
    //点击处理算法

    public abstract void OnStartTouch(Cube b);

    public abstract void Ontouch(Cube b);

    public abstract void OnRelaseTouch(Cube b);


 


}
