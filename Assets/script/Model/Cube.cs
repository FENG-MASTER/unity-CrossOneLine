using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {


    //全局的位置信息
    public static float init_x;
    public static float init_y;
    public static float height;
    public static float width;
    public static float scale;

    //每个方块的基本信息
    private int allCrossTimes = 0;//一共需要经过的次数
    private int crossTimes = 0;//还需要经过的次数

    public int x;//坐标信息
    public int y;

    private bool canTouch = false;

    //全局的标识
    public static bool startPress=false;

    private SpriteRenderer renderer;
 

    private SpriteRenderer labelRenderer;

    private GameObject touchReceiver;

    void Awake(){
        renderer = GetComponent<SpriteRenderer>();
        labelRenderer=GetComponentsInChildren<SpriteRenderer>()[1];//这个才是子组件中的
        touchReceiver = GameObject.Find("CubesPlane");
        

      
    }

    public void Init(int y,int x)
    {
        //初始化位置信息
        gameObject.transform.position = new Vector3(x * width + init_x
                                                    , init_y-y * height
                                                    , gameObject.transform.position.z);
        gameObject.transform.localScale = new Vector3(scale,scale,1);
        crossTimes = 0;
        allCrossTimes = 0;
        renderer.sprite = Res.instance.cubeSpriteList[0];
        this.x = x;
        this.y = y;
       
    }

    void Update(){
       //绘制相关

        labelRenderer.sprite = Res.instance.numberSpriteList[crossTimes];
        renderer.sprite = Res.instance.cubeSpriteList[crossTimes];


    }


    void OnMouseDown()
    {
      
     //   OnPress();
        touchReceiver.SendMessage("OnStartTouch", this);

    }

    void OnMouseUp()
    {
        touchReceiver.SendMessage("OnRelaseTouch", this);
    }



    void OnMouseEnter()
    {
        touchReceiver.SendMessage("Ontouch", this);
     
    }

    public void AddCrossTime(int time)
    {
        crossTimes += time;
        if(crossTimes>Res.instance.cubeSpriteList.Length){
            crossTimes = Res.instance.cubeSpriteList.Length;
        }

        allCrossTimes = crossTimes;
       
    }


 


   

    public void crossOneTime()
    {
        crossTimes--;
    }


    public void restore()
    {
       
        crossTimes = allCrossTimes;
        renderer.sprite = Res.instance.cubeSpriteList[crossTimes];
    }

    public bool hasCrossTime()
    {
        return crossTimes > 0;
    }

  

   

   

}
