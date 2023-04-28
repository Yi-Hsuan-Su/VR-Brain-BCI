using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSensor : MonoBehaviour
{
    public MazeGenerator maze;
    public float timer=0;
    public bool isblock=false;
    // Start is called before the first frame update
    void Start()
    {
        maze = GameObject.Find("MazeController").GetComponentInChildren<MazeGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isblock)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
                isblock = true;
        }
            
        
        
    }
     void OnTriggerEnter(Collider other)
    {

         if (other.tag== "Player"&&isblock)
        {
            timer = 0;
            isblock = false;
            maze.PlayerLocation++;
            maze.DynamicMap(maze.PlayerLocation);
            Debug.Log("PlayerLocation :" + maze.PlayerLocation);
        }
    }
   /* private void OnTriggerExit(Collider other)
    {
        if (other.name == "KAT_Player")
        {
            maze.PlayerLocation++;
        }
    }*/
}
