using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//全局计时器管理类
public class GameTimer : MonoBehaviour
{

    public static GameTimer instance;

    private List<Timer> timers;
  

    //单个计时器
    public  class Timer
    {

        private long startTime;//开始时间

        private long pauseDuration=0;
        private long startPauseTime;
        private bool pauseFlag=false;

        private bool startFlag = false;

        public delegate void RunEventHandle(double sec);//这里用的委托

        public RunEventHandle Run;//委托对象


        public Timer()
        {


        }

        //开始计时
        public void start()
        {
            if (pauseFlag)
            {
                pauseDuration += (System.DateTime.Now.Ticks-startPauseTime);
                pauseFlag = false;
            }
            else {
                startTime = System.DateTime.Now.Ticks;
                startFlag = true;
            }
        }

        public void stop()
        {
            startFlag = false;
            pauseDuration = 0;
            pauseFlag = false;
        }

        public void pause() {
            pauseFlag = true;
            startPauseTime = System.DateTime.Now.Ticks;
        }

        //更新时间
        public void Update()
        {
            if (startFlag && !pauseFlag)
            {
                Run(getSec());
            }

        }

        private double getSec()
        {
            long time = System.DateTime.Now.Ticks - startTime - pauseDuration;
            return System.Math.Round(time / 10000000f, 1);
        }



    }


    public void Add(Timer t)
    {
        timers.Add(t);

    }

    public void Remove(Timer t)
    {
        
        timers.Remove(t);
    }


    void Awake()
    {
        timers = new List<Timer>();
        instance = this;
    }


 
    void Update()
    {
        for (int i = 0; i < timers.Count;i++ )
        {
            timers[i].Update();
        }

    }

   

}
