

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.LSL4Unity.Scripts;

public class PokerController : MonoBehaviour
{
    public SteamVR_TrackedObject trackdeObjec;
    public GameObject t;
    public SpriteRenderer pokerrender;
    public Sprite[] pokerdata;
    public float coldtime = 1.0f, click_time = 0.5f,showtime;
    public float timer = 4, ResTimer = 1;
    public int num = 0;
    public bool isStart = false;
 
    public TextMesh Score, Log;
    public int target = 0, total = 0;
    public LSLMarkerStream marker;
    public int last_duration= -1, last_latency = -1,last_pokernum= -1;
    float[] duration = { 1, 2, 4 };//事件間膈時間
    float[] latency = { 0.25f, 0.5f, 0.75f };//出現時間
    int count = 0;

    // Use this for initialization
    void Start()
    {
        trackdeObjec = GameObject.Find("Controller (right)").GetComponent<SteamVR_TrackedObject>();
        t = GameObject.Find("PokerRender");
        pokerrender = t.GetComponent<SpriteRenderer>();
        marker = GameObject.Find("LabStreamingLayer").GetComponentInChildren<LSLMarkerStream>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            PostCard();
        }
        Score.text = "("+target + "/" + total+")"+ "\n"+
                      "Duration :" + coldtime + "\n" +
                      "Latency :" + showtime +"\n"  ;

    }
    void FixedUpdate()
    {
        if (isStart)
            RespondUseController();
    }
    void PostCard()//隨機發牌
    {
      

        if (timer >= coldtime)
        {
            //動態改變latency，每5個隨機挑選latency
            if (total % 5 == 0)
            {
                int jtmp;
                jtmp = Random.Range(0, 3);
                while (jtmp == last_latency)
                {
                    jtmp = Random.Range(0, 3);
                }
                last_latency = jtmp;
                showtime = latency[jtmp];
            }
            //動態改變coldtime，每20個隨機挑選duration
            if (total % 20 == 0)
            {
                int tmp;
                tmp = Random.Range(0, 3);
                while (tmp == last_duration)
                {
                    tmp = Random.Range(0, 3);
                }
                last_duration = tmp;
                coldtime = duration[tmp];
            }

            num = Random.Range(1, 10);
            pokerrender.sprite = pokerdata[num];
            timer = 0;
            ResTimer = 1;
            total++;

            //LSL
            if (num != 1)//非目標
            {
               
                //根據latency給予marker
                switch(showtime)
                {
                    case 0.25f:
                        marker.Write(200);
                        break;
                    case 0.5f:
                        marker.Write(201);
                        break;
                    case 0.75f:
                        marker.Write(202);
                        break;
                }
            }
            else//目標
            {
                switch (showtime)
                {
                    case 0.25f:
                        marker.Write(210);
                        break;
                    case 0.5f:
                        marker.Write(211);
                        break;
                    case 0.75f:
                        marker.Write(212);
                        break;
                }
              
            }

           switch(coldtime)
            {
                case 1:
                    marker.Write(231);
                    break;
                case 2:
                    marker.Write(232);
                    break;
                case 4:
                    marker.Write(234);
                    break;
            }
        }
        else
        {
            timer = timer + Time.deltaTime;
            if(timer>=showtime)
            {
                pokerrender.sprite = pokerdata[0];
                
            }
        }




    }
    void Respond()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("SpaceOnClick!!");
            CheckCard();
        }
    }

    //黑桃一不能按，其他都能按
    public void CheckCard()
    {
        string temp;
        if (num == 1)
        {
            temp = "Error!!";
            Log.color = Color.red;
            Debug.Log(temp);

        }
        else
        {
            temp = "Correct!!";
            Log.color = Color.green;
            Debug.Log(temp);
            target++;
        }
        Log.text = temp;
    }

    void RespondUseController()
    {
        var device = SteamVR_Controller.Input((int)trackdeObjec.index);

        ResTimer = ResTimer + Time.deltaTime;
        if (ResTimer >= click_time&&num!=0)
        {
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("按下了 Touchpad ");
                CheckCard();
                ResTimer = 0;
                //LSL
                marker.Write(220);
            }
        }
    }


}



