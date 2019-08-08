using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner3BehaviourScript : MonoBehaviour
{
    GameObject spinner3;
    long lastRotationChange;
    Vector3 startingPosition;
    float spinRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        spinner3 = GameObject.Find("Spinner3");
        startingPosition = spinner3.transform.position;
        lastRotationChange = System.Environment.TickCount;
    }

    // Update is called once per frame
    void Update()
    {
        long delta = System.Environment.TickCount - lastRotationChange;
        if (delta > 30)
        {
            lastRotationChange = System.Environment.TickCount;
            spinner3.transform.Rotate(new Vector3(0, -(360 * delta / 1000f) * spinRate, 0));
            spinner3.transform.position = new Vector3(
               startingPosition.x,
               (float)System.Math.Sin(System.Environment.TickCount / 500f) / 10 + startingPosition.y,
               startingPosition.z);
        }

    }

}