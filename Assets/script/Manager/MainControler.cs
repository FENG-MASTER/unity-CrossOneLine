using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainControler : MonoBehaviour {


    private int level=0;
    public static MainControler instance;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadSceneAsync(0);
        }

	}


    public void startGame()
    {
        startGameByLevel();
    }


    public void finishLevel()
    {

    }

    private void startGameByLevel()
    {
        level++;
        Cubes.instance.NewGame(5,level+15);
    }

   

}
