using UnityEngine;
using System.Collections;

public class Res : MonoBehaviour {

    public static Res instance;
    public Sprite[] numberSpriteList;
    public Sprite[] cubeSpriteList;
    public GameObject cubePrefab;

    public UILabel label_level;

    public GameObject gameBackGround;

    public AudioClip source_click;



    void Awake()
    {
        instance = this;
    }
}
