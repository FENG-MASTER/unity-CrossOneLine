using UnityEngine;
using System.Collections;

public class ScreenManeger : MonoBehaviour {

    /// <summary>
    /// 确保屏幕一直保持竖屏
    /// </summary>
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;

        Camera.main.orthographicSize = Screen.height / 100.0f / 2.0f;//设置orthographicSize的值为屏幕高一半

	}

}
