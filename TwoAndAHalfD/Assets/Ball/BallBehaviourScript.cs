using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    GameObject ball;
    System.Random random;
    Vector3 startingBallPosition;
    GameObject floor;

    public enum BallState
    {
        Bouncing,
        SpinnerMoving,
    }

    static public BallState ballState = BallState.Bouncing;

    // Start is called before the first frame update
    void Start()
    {
        ball  = GameObject.Find("Ball");
        random = new System.Random();
        startingBallPosition = ball.transform.position;
        ball.transform.position = new Vector3(ball.transform.position.x + (float)random.NextDouble() * 6, ball.transform.position.y, ball.transform.position.z);

        floor = GameObject.Find("Floor");
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
            return;
            var collider = ball.GetComponent<SphereCollider>();

            var physicsMaterial = collider.GetComponent<PhysicMaterial>();

            physicsMaterial.bounciness = (float) random.NextDouble();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ballState == BallState.Bouncing)
        {
            FixBadBallStartingPosition();
        }
        
    }

    private void FixBadBallStartingPosition()
    {
        if (ball.transform.position.y < floor.transform.position.y)
        {
            ball.transform.position = startingBallPosition;
        }
    }
}
