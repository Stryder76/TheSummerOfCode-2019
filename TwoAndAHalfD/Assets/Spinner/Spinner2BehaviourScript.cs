using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner2BehaviourScript : MonoBehaviour
{
    GameObject spinner;
    long lastRotationChange;
    Vector3 startingPosition;
    float spinRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        spinner = GameObject.Find("Spinner2");
        lastRotationChange = System.Environment.TickCount;
        startingPosition = spinner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        long delta = System.Environment.TickCount - lastRotationChange;
        if (delta > 30)
        {
            lastRotationChange = System.Environment.TickCount;
            spinner.transform.Rotate(new Vector3(0, -(360 * delta / 1000f) * spinRate, 0));

            spinner.transform.position = new Vector3(
               startingPosition.x,
               (float)System.Math.Cos(System.Environment.TickCount / 500f) /10 + startingPosition.y,
               startingPosition.z);
        }

    }

}
