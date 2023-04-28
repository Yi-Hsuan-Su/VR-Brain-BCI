using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{

    public GameObject StraightWall, TurnLeftWall, TurnRightWall ;
    GameObject[] tmp = new GameObject[20];
    public Transform tran , next_tran;
    public int PlayerLocation = 0;
    //private int[] MazeData = {0, 1, 2, 0, 1, 2, 0, 1, 2, 0 };
    private int[] MazeData =new int[20];
    public int length, index, next_index,pre_direction=0,direction=0 ;
    private GameObject[] source = new GameObject[3];
    
    // Use this for initialization
    void Start () {
        length = 20;
        source[0] = StraightWall;
        source[1] = TurnLeftWall;
        source[2] = TurnRightWall;
        RandomMazeData(length);//隨機生成0~2陣列
        MazeData[0] = 0;
        InitPreDirection(MazeData[0]);//設定前項起始值
        CreateMaze(length);
        for(int i=0;i<MazeData.Length;i++)
        Debug.Log(MazeData[i]);
        DynamicMap(PlayerLocation);
    }
	
	// Update is called once per frame
	void Update () {
     //  DynamicMap(PlayerLocation);
	}

    public void CreateMaze(int n)
    {
        for (int i = 0; i < n; i++)
        {
            index = MazeData[i];
            
            if (i < n-1)
            {
                next_index = MazeData[i+1];
            }
            tmp[i] = Instantiate(source[index]);

            if (i > 0)
            {
                tmp[i].gameObject.transform.position = next_tran.position;
 
               if (MazeData[i] == 0)
                {
                    switch (pre_direction)
                    {
                        case 0:                       
                            direction = 0;
                           // tmp[i].gameObject.transform.position += new Vector3(0, 0,0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 0, 0));
                            break;
                        case 1:
                            direction = 1;
                            //tmp[i].gameObject.transform.position += new Vector3(0, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 90, 0));
                            break;
                        case 2:
                            direction = 2;
                           // tmp[i].gameObject.transform.position += new Vector3(0, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 180, 0));
                            break;
                        case 3:
                            direction = 3;
                            //tmp[i].gameObject.transform.position += new Vector3(0, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 270, 0));
                            break;
                    }
                }

                else if (MazeData[i] == 1)
                {
                    switch (pre_direction)
                    {
                        case 0:
                            direction = 3;
                            //tmp[i].gameObject.transform.position += new Vector3(-12, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 0, 0));
                            break;
                        case 1:
                            direction = 0;
                            //tmp[i].gameObject.transform.position += new Vector3(-12, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 90, 0));
                            break;
                        case 2:
                            direction = 1;
                           // tmp[i].gameObject.transform.position += new Vector3(-12, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 180, 0));
                            break;
                        case 3:
                            direction = 2;
                            //tmp[i].gameObject.transform.position += new Vector3(-8, 0, 1);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 270, 0));
                            break;
                    }


                }
                else if (MazeData[i] == 2)
                {
                    switch (pre_direction)
                    {
                        case 0:
                            direction = 1;
                            //tmp[i].gameObject.transform.position += new Vector3(-12, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 0, 0));
                            break;
                        case 1:
                            direction = 2;
                            //tmp[i].gameObject.transform.position += new Vector3(0, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 90, 0));
                            break;
                        case 2:
                            direction = 3;
                           // tmp[i].gameObject.transform.position += new Vector3(-12, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 180, 0));
                            break;
                        case 3:
                            direction = 0;
                           // tmp[i].gameObject.transform.position += new Vector3(-12, 0, 0);
                            tmp[i].gameObject.transform.Rotate(new Vector3(0, 270, 0));
                            break;
                    }

                    //tmp[i].gameObject.transform.position += new Vector3(0, 2, 0);
                   
                }
          
                pre_direction = direction;

            }

            //設定給下一位(next_tran)要用的位置
            tran = tmp[i].gameObject.transform;
           
                if (pre_direction == 0)
                {
                next_tran.position = tran.position + new Vector3(0, 0, 90);
                }
                else if (pre_direction == 1)
                {
                 next_tran.position = tran.position + new Vector3(90, 0, 0);
                }
                else if (pre_direction == 2)
                {
                 next_tran.position = tran.position + new Vector3(0, 0, -90);
                }

                else if (pre_direction == 3)
                {
                 next_tran.position = tran.position + new Vector3(-90, 0, 0);
                }




            


        }

    }
    public void InitPreDirection(int j)
    {
        switch(j)
        {
            case 0:
                pre_direction = 0;
                break;
            case 1:
                pre_direction = 3;
                break;
            case 2:
                pre_direction = 1;
                break;
        }
    }
    public void RandomMazeData(int length)
    {
        int i;
        for (i=0;i<length;i++)
        {    
            //防止連續三個左右彎
            if(i>3)
            {
                if(MazeData[i-1]== 2 &&  MazeData[i-2] == 2)
                {
                    MazeData[i] = 1;
                }
                else if(MazeData[i - 1] == 1 && MazeData[i - 2] == 1)
                {
                    MazeData[i] = 2;
                }
                else
                {
                    MazeData[i] = Random.Range(0, 3);
                }
            }
            else
            {
                MazeData[i] = Random.Range(0, 3);
            }
            MazeData[i] = Random.Range(0, 3);
        }
    }
    public void DynamicMap(int location)
    {
       
        CloseAllMAp();
        if(location==0)
        {
            tmp[0].gameObject.SetActive(true);
            tmp[1].gameObject.SetActive(true);
            tmp[2].gameObject.SetActive(true);
        }
        else if(location==length)
        {
            tmp[length].gameObject.SetActive(true);
            tmp[length-1].gameObject.SetActive(true);
        }
        else
        {
           
            tmp[location-1].gameObject.SetActive(true);
            tmp[location].gameObject.SetActive(true);
            tmp[location+1].gameObject.SetActive(true);
        }
        

    }
    public void CloseAllMAp()
    {
        for(int i=0;i<length;i++)
        {
            tmp[i].gameObject.SetActive(false);
        }
    }
}
