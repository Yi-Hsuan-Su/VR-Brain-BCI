using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.LSL4Unity.Scripts;

public class Soundcontrol : MonoBehaviour {


    public AudioSource[] bippsound;
    private GameObject target;
    private bool Check;
    private AudioSource tempsound;
    public bool isStart = false;
    public float Timer = 1.0f;
    public LSLMarkerStream marker;//B0,B1
    void Start()
    {
        marker = GameObject.Find("LabStreamingLayer").GetComponentInChildren<LSLMarkerStream>();
        /*  target = GameObject.Find("Camera");
          Check = target.GetComponent<Mapview>().check;
          if (Check)
          {
              this.InvokeRepeating("playbipp", 0.8f, 0.8f);
          }*/
        //this.InvokeRepeating("playbipp", 0f, 0.8f); //關於間隔參數問題目前0.8f比較接近 https://www.youtube.com/watch?v=ZJ-YB0YIdmM 這個 但實際參數還需要參考
    }

     void Update()
    {
        if (isStart)
        {
           
            if (Timer >= 1.0f)
            {
                
                playbipp();
                Timer = 0;
            }
            else
            {
                Timer += Time.deltaTime;
            }
           
            
        }
        
    }
    public void playbipp()
    {


        System.Random rsd = new System.Random();

        if (rsd.Next(1, 10000) <7543  ) {
            bippsound[0].Play();
            tempsound = bippsound[0];
            marker.Write(300);
            //Debug.Log("300");
        }
        else 
        {
            if (tempsound != bippsound[1])
            {
                bippsound[1].Play();
                tempsound = bippsound[1];
                marker.Write(301);
                //Debug.Log("301");
            }
            else {
                bippsound[0].Play(); tempsound = bippsound[0];
                marker.Write(300);
                //Debug.Log("200");
            }
        }

    }
}
