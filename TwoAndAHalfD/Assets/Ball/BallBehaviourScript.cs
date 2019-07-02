using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      GameObject ball = GameObject.Find("Ball");
        var random = new System.Random();
        ball.transform.position = new Vector3(ball.transform.position.x + (float)random.NextDouble() * 6, ball.transform.position.y, ball.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collider)

    {


        if (collider.name == "RightOfTheMiddleChannel")
        {
            ScoreBehavior.score += 3;
        }

        if (collider.name == "RightChannelTip")
        {
            ScoreBehavior.score += 7;
        }







        if (collider.name == "LeftChannelTip")
        {
            ScoreBehavior.score+= 2;
        }


    }




    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.name == "Peg(Clone)")
        {
            ScoreBehavior.score++;
        }

        
       
    }
}
