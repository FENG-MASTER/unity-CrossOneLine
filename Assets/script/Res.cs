﻿using UnityEngine;
using System.Collections;

public class Res : MonoBehaviour {

    public static Res instance;
    public Sprite[] numberSpriteList;
    public GameObject cubePrefab;
    public Sprite cubeSprite;

    void Awake()
    {
        instance = this;
        
    }

    


	// Update is called once per frame
	void Update () {
	
	}
}
