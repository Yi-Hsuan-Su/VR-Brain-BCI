using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterrender : MonoBehaviour
{
    // Start is called before the first frame update

    float scrollSpeedx= 0.02f;
    float scrollSpeedy = 0.03f;
    Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offsetx = Time.time * scrollSpeedx;
        float offsety = Time.time * scrollSpeedy;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetx, offsety));
    }
}
