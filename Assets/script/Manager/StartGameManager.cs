using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour {


    public void OnStartGameButtonClick()
    {
        //游戏开始
        //载入场景01
        SceneManager.LoadSceneAsync(Util.SCENES_MODE_CHOOSE);


    }
}
