using UnityEngine;
using System.Collections;

public class Res : MonoBehaviour {

    public static Res instance;
    public Sprite[] numberSpriteList;
    public Sprite[] cubeSpriteList;
    public GameObject cubePrefab;



    void Awake()
    {
        instance = this;
        
    }

    


	// Update is called once per frame
	void Update () {
	
	}
}
