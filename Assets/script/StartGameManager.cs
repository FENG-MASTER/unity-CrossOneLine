using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void OnStartGameButtonClick()
    {
        //游戏开始
        //载入场景01
        SceneManager.LoadSceneAsync(1);


    }
}
