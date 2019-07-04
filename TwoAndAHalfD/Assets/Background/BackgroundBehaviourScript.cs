using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviourScript : MonoBehaviour
{
    GameObject backround;
    System.Random random;
    // Start is called before the first frame update
    void Start()
    {
         random = new System.Random();
        backround = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
    
        backround.GetComponent<Renderer>().sharedMaterial.color = new Color((float)random.NextDouble(),(float)random.NextDouble(), (float)random.NextDouble());
    }
}
