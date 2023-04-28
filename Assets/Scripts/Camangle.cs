using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KATVR;

public class Camangle : MonoBehaviour
{
    public bool locker;
    float speed = 0.03f;
    //public MazeGenerator maze;
    private Transform tran;
    public float timer = 0;
    public GameObject RotateObject;
    private  float tempangle;
    private float Llimit, Rlimit;
    public bool isStart = false;
    //private CamangleIO m_camangleio;
    // Start is called before the first frame update
    void Start()
    {
        locker = true;
        Llimit = 270;
        Rlimit = 90;
        tempangle = KATVR.KATVR_Global.KDevice_Walk.bodyRotation;
       // m_camangleio = GetComponent<CamangleIO>();
        tran = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            Moving();
        }
       
     
    }

    //鏡頭推進
    public void Moving()
    {
        tran.position = tran.position + PickVector() * speed;
       // tran.localEulerAngles = new Vector3(tran.localEulerAngles.x, KATDevice_Walk.Instance.bodyYaw, tran.localEulerAngles.z);
    }

    //根據地形給予鏡頭行進方向
    public Vector3 PickVector()
    {

        if (RotateObject.transform.rotation.eulerAngles.y >= Llimit || RotateObject.transform.rotation.eulerAngles.y <= Rlimit)
        {
            if (locker == false)
            {
                if (RotateObject.transform.rotation.eulerAngles.y > Rlimit - 10)
                {
                    poschange('R');
                    //m_camangleio.Save("001"); 
                }
                else if (RotateObject.transform.rotation.eulerAngles.y > Llimit + 10)
                {
                    poschange('L');
                    //m_camangleio.Save("001");
                }
            }
            //Debug.Log(Rlimit);
            //Debug.Log(Llimit);
            //return  ;
            //return new Vector3(0, 0, 1);
           // Debug.Log("RotateObject.transform.forward:"+RotateObject.transform.forward);
            return RotateObject.transform.rotation* Vector3.forward;
            
        }
        else
        {
            //Debug.Log("Else :" + Vector3.forward);
            // return Vector3.forward;
            return RotateObject.transform.rotation * Vector3.forward;
        }

      
        

    }


    public void poschange(char C)
    {
        if (C == 'R')
        {
            Llimit = Llimit + 90;
            Rlimit = Rlimit + 90;
            if (Llimit >= 360) Llimit -= 360;
            if (Rlimit >= 360) Rlimit -= 360;
        }
        else if(C=='L')
        {
            Llimit = Llimit - 90;
            Rlimit = Rlimit - 90;
            if (Llimit < 0) Llimit += 360;
            if (Rlimit < 0) Rlimit += 360;
        }
        

    }

}




