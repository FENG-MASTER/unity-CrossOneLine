using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    private static Color[] colorList={Color.grey,Color.black,Color.blue,Color.cyan,Color.red};

    private int crossTimes = 0;
    private Color color = Color.grey;

    private Renderer renderer;
    private Material material;

    private SpriteRenderer labelRenderer;

    void Awake(){
        renderer=GetComponent<Renderer>();
        labelRenderer=GetComponentsInChildren<SpriteRenderer>()[1];
        material = renderer.sharedMaterial;
        material.color=getColor();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.A)){
            AddCrossTime(1);   
        }
        material.color = getColor();
        labelRenderer.sprite = Res.instance.numberSpriteList[crossTimes];
    }

    public void AddCrossTime(int time)
    {
        crossTimes += time;
        if(crossTimes>colorList.Length){
            crossTimes = colorList.Length;
        }
       
    }

    public Color getColor()
    {
        return colorList[crossTimes];
    }

   

}
