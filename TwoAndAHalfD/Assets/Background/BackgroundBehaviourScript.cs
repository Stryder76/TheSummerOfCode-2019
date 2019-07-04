using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviourScript : MonoBehaviour
{
    long lastcolorticks;
    GameObject backround;
    System.Random random;
    // Start is called before the first frame update
    void Start()
    {
         random = new System.Random();
        lastcolorticks = System.Environment.TickCount;
        backround = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        long delta = System.Environment.TickCount - lastcolorticks;
        if (delta > 500)
        {
            lastcolorticks = System.Environment.TickCount;
            backround.GetComponent<Renderer>().sharedMaterial.color = new Color((float)random.NextDouble(),(float)random.NextDouble(), (float)random.NextDouble());
        }

    }
}
