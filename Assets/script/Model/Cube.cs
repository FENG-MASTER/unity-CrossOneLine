using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private List<int> stepsList = new List<int>();

    private SpriteRenderer renderer;//渲染器
 
    private TextMesh mainTextLabel;
    private TextMesh requestTextLabel;
   

    private CubeTouchHandler touchHandler=new DefalutCubeTouchHandler();//点击处理器

    private TweenAlpha TA;//自身贴图的动画
    private TweenAlpha TA_num;//数字贴图的动画



    void Awake(){
        renderer = GetComponent<SpriteRenderer>();
        mainTextLabel = GetComponentsInChildren<TextMesh>()[0];
        requestTextLabel = GetComponentsInChildren<TextMesh>()[1];
        TA = GetComponent<TweenAlpha>();
        TA_num = GetComponentInChildren<TweenAlpha>();
        
       
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
        stepsList.Clear();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        touchHandler = new DefalutCubeTouchHandler();
        touchHandler.Init(this);
        showRequestNum(0);
    }

    void Update(){
       //绘制相关
        mainTextLabel.text = crossTimes + "";
        renderer.sprite = Res.instance.cubeSpriteList[crossTimes];

        touchHandler.Update();//执行下触摸处理器的更新方法
    }


    void OnMouseDown()
    {
        touchHandler.OnStartTouch(this);
    }

    void OnMouseUp()
    {
        touchHandler.OnRelaseTouch(this);
    }



    void OnMouseEnter()
    {
        touchHandler.Ontouch(this);
    }

    public void AddCrossTime(int time)
    {
        crossTimes += time;
        if(crossTimes>Res.instance.cubeSpriteList.Length){
            crossTimes = Res.instance.cubeSpriteList.Length;
        }

        allCrossTimes = crossTimes;
       
    }

    static bool show=false;
    

    public void crossOneTime(int n=1)
    {
        crossTimes-=n;
        playTween();
        AudioSource.PlayClipAtPoint(Res.instance.source_click, gameObject.transform.position);
    }

    /// <summary>
    /// 恢复数据,恢复到游戏开始的时候(每个方块上都有步数要求)的状态(非0)
    /// </summary>
    public void restore()
    {
       
        crossTimes = allCrossTimes;
        renderer.sprite = Res.instance.cubeSpriteList[crossTimes];

      
    }

    public int getNeedCrossTime()
    {
        return crossTimes;
    }


    /// <summary>
    /// 播放点击动画
    /// </summary>
    private void playTween()
    {


        //播放点击动画
        TA.enabled = true;
        TA_num.enabled = true;

        TA.PlayForward();
        TA_num.PlayForward();

        TA.AddOnFinished(delegate()
        {
            TA.PlayReverse();//倒放
        });

        TA_num.AddOnFinished(delegate() {
            TA_num.PlayReverse();//倒放
        });
    }

    public void setTouchHandler(CubeTouchHandler handler)
    {
        touchHandler = handler;
        touchHandler.Init(this);
    }

    public CubeTouchHandler getTouchHandler()
    {
        return touchHandler;
    }

    public void addStep(int s)
    {
        stepsList.Add(s);
    }

    public List<int> getSteps()
    {
        return stepsList;
    }

    public void showRequestNum(int step)
    {
        if(step>0){
            requestTextLabel.text = step + "";
        }
        else
        {
            requestTextLabel.text = "";
        }
   }

   




   

}
