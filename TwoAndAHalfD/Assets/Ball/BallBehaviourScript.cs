using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    GameObject ball;
    System.Random random;
    Vector3 startingBallPosition;
    GameObject floor;

    enum BallState
    {
        Bouncing,
        SpinnerMoving,
    }

    BallState ballState = BallState.Bouncing;

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

            ball.GetComponent<PhysicMaterial>().bounciness = (float) random.NextDouble();
        }
        if (collision.collider.name == "Spinner" 
            || collision.collider.name == "Spinner2")
        {
            ballState = BallState.SpinnerMoving;
            var ballRigidBody = ball.GetComponent<Rigidbody>();
            ballRigidBody.useGravity = false;
            ballRigidBody.constraints = ballRigidBody.constraints & ~RigidbodyConstraints.FreezePositionZ;
            spinnerStart = System.Environment.TickCount;
            spinnerBallHitStartPosition = ball.transform.position;
        }
    }

    long spinnerStart = 0;
    Vector3 spinnerBallHitStartPosition;
    // Update is called once per frame
    void Update()
    {
        if (ballState == BallState.Bouncing)
        {
            FixBadBallStartingPosition();
        }
        else if (ballState == BallState.SpinnerMoving)
        {
            long delta = System.Environment.TickCount - spinnerStart;
            float deltaSeconds = delta / 1000f;
            var initialZVelocity = -3f;
            var initialYVelocity = 2f;
            var zPosition = spinnerBallHitStartPosition.z + initialZVelocity * deltaSeconds + 1f * deltaSeconds * deltaSeconds;
            var yPosition = spinnerBallHitStartPosition.y + initialYVelocity*deltaSeconds;

            ball.transform.position = new Vector3(ball.transform.position.x, yPosition, zPosition);

            if (ball.transform.position.y >= startingBallPosition.y)
            {
                var ballRigidBody = ball.GetComponent<Rigidbody>();
                ballRigidBody.useGravity = true;
                ball.transform.position = new Vector3(spinnerBallHitStartPosition.x, ball.transform.position.y, spinnerBallHitStartPosition.z);
                ballRigidBody.constraints = ballRigidBody.constraints | RigidbodyConstraints.FreezePositionZ;
                ballState = BallState.Bouncing;
            }
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
