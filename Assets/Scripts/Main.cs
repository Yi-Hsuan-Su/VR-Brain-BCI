using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.LSL4Unity.Scripts;
public class Main : MonoBehaviour
{
    public PokerController PokerCPT;
    public Soundcontrol OddBall;
    public Camangle Player;
    public bool isGameStart = false, isQ = false, isW = false, isE = false, isR = false;
    public bool isA = false, isS = false, isD = false,isF=false, isZ = false,isX=false;
    public float timer = 1,StartTimer=0;
    public float Qtimer = 60, Wtimer = 60, Etimer = 60, Rtimer = 60;
    public float Atimer = 60, Stimer = 60, Dtimer = 60,Ftimer=60, Ztimer = 60, Xtimer=30;
    public float input_timer = 0.1f;
    private float speed = 0.05f;
    public TextMesh StartTxt;
    public LSLMarkerStream marker;
    // Start is called before the first frame update
    void Start()
    {
        marker = GameObject.Find("LabStreamingLayer").GetComponentInChildren<LSLMarkerStream>();
        Qtimer = Wtimer = Etimer =  Rtimer = Atimer =  Stimer =  Dtimer = Ftimer= Ztimer =600 ;
    }

    // Update is called once per frame
    void Update()
    {
        if(input_timer>=0.1f)
        {
            StartSignal();
            input_timer = 0;
        }
        else
        {
            input_timer += Time.deltaTime;
        }
        TimeMaster(); 
    }

    void CallOther()
    {
        PokerCPT.isStart = isGameStart;
        OddBall.isStart = isGameStart;
        Player.isStart = isGameStart;
    }

    void StartSignal()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ResetTimer();
           
            isGameStart = true;
            isQ = true;
            if (isGameStart)
            {
                marker.Write(100);
                Debug.Log("GameStart!!: Stand ");
                StartTxt.gameObject.SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            ResetTimer();
            isW = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(102);
                Player.isStart = isGameStart;
                Debug.Log("GameStart!!: Walk ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.E))
        {
            ResetTimer();
            isE = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(104);
                PokerCPT.isStart = isGameStart;
                Debug.Log("GameStart!!: CPT ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.R))
        {
            ResetTimer();
            isR = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(106);
                OddBall.isStart = isGameStart;
                Debug.Log("GameStart!!: OB ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            ResetTimer();
            isA = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(108);
                Player.isStart = isGameStart;
                PokerCPT.isStart = isGameStart;
                Debug.Log("GameStart!!: Walk + CPT ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            ResetTimer();
            isS = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(110);
                Player.isStart = isGameStart;
                OddBall.isStart = isGameStart;
                Debug.Log("GameStart!!: Walk + OB ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            ResetTimer();
            isD = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(112);
                CallOther();
                Debug.Log("GameStart!!: Walk + CPT + OB ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.F))
        {
            ResetTimer();
            isF = true;
            isGameStart = true;
            if (isGameStart)
            {
                marker.Write(114);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
                
                Debug.Log("GameStart!!:  CPT + OB ");
                StartTxt.gameObject.SetActive(true);
            }

        }
        if (Input.GetKey(KeyCode.Z))
        {
            ResetTimer();
            isZ = true;
           // isGameStart = true;
            if (isGameStart)
            {
                isGameStart = false;
                isQ = isW =  isE =  isR = isA =  isS = false;
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
                Player.isStart = isGameStart;
                Debug.Log("GameEnd!! ");
                StartTxt.gameObject.SetActive(true);
            }

        }

        if (Input.GetKey(KeyCode.X))
        {
            ResetTimer();
            isX = true;
            isGameStart = true;
            marker.Write(116);
            Debug.Log("GameStart!!:  Eye  ");
            StartTxt.gameObject.SetActive(true);
           

        }
    }

    void TimeMaster()
    {
        if(isGameStart)
        {
            timer += Time.deltaTime;
            StartTxt.text = "" + timer;
        }
        if(isQ)
        {
            if (timer >= Qtimer)
            {
                ResetTimer();
                isGameStart = false;
                marker.Write(101);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isW)
        {
            if (timer >= Wtimer)
            {
                ResetTimer();
                isGameStart = false;
                Player.isStart = isGameStart;
                marker.Write(103);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isE)
        {
            if (timer >= Etimer)
            {
                ResetTimer();
                isGameStart = false;
                marker.Write(105);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isR)
        {
            if (timer >= Rtimer)
            {
                ResetTimer();
                isGameStart = false;
                marker.Write(107);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }

        if (isA)
        {
            if (timer >= Atimer)
            {
                ResetTimer();
                isGameStart = false;
                Player.isStart = isGameStart;
                marker.Write(109);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isS)
        {
            if (timer >= Stimer)
            {
                ResetTimer();
                isGameStart = false;
                Player.isStart = isGameStart;
                marker.Write(111);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isD)
        {
            if (timer >= Dtimer)
            {
                ResetTimer();
                isGameStart = false;
                Player.isStart = isGameStart;
                marker.Write(113);
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isF)
        {
            if (timer >= Ftimer)
            {
                ResetTimer();
                isGameStart = false;
               
                marker.Write(115);
                //各任務參數
                Player.isStart = isGameStart;
                PokerCPT.isStart = isGameStart;
                OddBall.isStart = isGameStart;
            }
        }
        if (isX)
        {
            if (timer >= Xtimer)
            {
                ResetTimer();
                isGameStart = false;
                marker.Write(117);
                //各任務參數
               
            }
        }

    }

    void ResetTimer()
    {
        isQ =  isW =  isE = isR = false;
        isA =  isS =  isD =isZ =isX = false;
        timer = 0;
     }
    void EndGame()
    {

    }
}
