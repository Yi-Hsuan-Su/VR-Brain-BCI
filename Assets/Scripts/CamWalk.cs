using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamWalk : MonoBehaviour
{
    public float speed = 0;
    //public MazeGenerator maze;
    private Transform tran;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        tran = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        if (Input.GetKey(KeyCode.Space))
        {
            Moving();
            Debug.Log("moving");
        }
    }

    //鏡頭推進
    public void Moving()
    {
        tran.position = tran.position + PickVector()*speed;
    }

    //根據地形給予鏡頭行進方向
    public Vector3 PickVector()
    {
        return new Vector3(0,0,1);
    }
}
