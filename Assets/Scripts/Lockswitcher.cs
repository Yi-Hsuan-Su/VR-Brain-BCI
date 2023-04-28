using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LSL4Unity.Scripts;

public class Lockswitcher : MonoBehaviour
{
    //private Camangle cama;
    public Camangle m_camamgle;
    public LSLMarkerStream marker;//C0,C1
    private void Start()
    {
        m_camamgle = GameObject.Find("KAT_Player").GetComponentInChildren<Camangle>();
        marker = GameObject.Find("LabStreamingLayer").GetComponentInChildren<LSLMarkerStream>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name== "KAT_Player")
        {
            marker.Write(401);
            m_camamgle.locker = false;
        }
    }
       
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "KAT_Player")
        {
            marker.Write(402);
            m_camamgle.locker =true;
        }
    }
}
