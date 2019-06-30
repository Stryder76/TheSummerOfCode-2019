using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    Vector3 cameraStartingPosition;
    GameObject cameraObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cameraStartingPosition = cameraObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        cameraObject.transform.position =
                new Vector3(
                       (float)System.Math.Sin(System.Environment.TickCount/1000f)/10 + cameraStartingPosition.x,
                       (float)System.Math.Cos(System.Environment.TickCount/1000f)/10 + cameraStartingPosition.y,
                       (float)System.Math.Sin(System.Environment.TickCount/1000f)/10 + cameraStartingPosition.z);
    }
}
