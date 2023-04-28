using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddlecreator : MonoBehaviour
{
    public GameObject [] position;
    public GameObject puddleprefab;
    void Start()
    {

        int []record = new int[10];
        int  index=0 ,count=0 ;

   /*    while (count < 10)
        {
           int  rsd = count;
        
                Instantiate(puddleprefab, position[rsd].transform.position, position[rsd].transform.rotation).transform.parent = this.transform;
                count++;
        }
       */
  while (count<3)
           {
               int rsd = Random.Range(0, 9);
               if (!checkrepeat(record, rsd))
               {
                   record[index++] = rsd;
                   Instantiate(puddleprefab, position[rsd].transform.position, position[rsd].transform.rotation).transform.parent = this.transform;

                   count++;
               }
           }

    }

    bool checkrepeat(int[] record , int num)
    {
        for (int i = 0; i < record.Length; i++)
        {
            if (record[i] == num)
            {
                return true;
            }
        }
        return false;
    }
    // Update is called once per frame

}
