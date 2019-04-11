/*using System;
using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config
    [SerializeField] Paddle paddle1;
    [SerializeField] float ballVeloX = 1f; //velocity of the ball at launch
    [SerializeField] float ballVeloY = 14.5f;
    [SerializeField] AudioClip[] ballSounds; //array fo audio clips used for the ball
    [SerializeField] float volume = .04f; //set the volume
    [SerializeField] float randomFactor = .02f; //added to help fix the bug where the ball gets stuck on a horizonal axis


    bool hasStarted = false;

    //state
    Vector2 paddleDistVect; //distance (gap) between the paddle and the ball

    //Cached Component References
    AudioSource ballAudio;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        //calc the distance beetween ball and paddle
        paddleDistVect = transform.position - paddle1.transform.position; //ball pos - paddle pos

        //when game starts, get needed references
        ballAudio = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            BallStart(); //locks the ball to the paddle at the start/restart of each level
        }
        
        LaunchBall(); //launches the ball from the paddle on click
    }

    private void LaunchBall()
    {
        //if player clicks left mouse while ball is locked on paddle, launch ball
        if (Input.GetMouseButtonDown(0)) //0 is used for left mouse click
        {
            //launch ball by using it's rigidbody2d body in Unity
            myRigidBody2D.velocity = new Vector2(ballVeloX, ballVeloY);
            hasStarted = true; //once the player clicks, it's no longer the "start" of the level
            //so the ball doesn't need to be locked to the paddle anymore
        }
    }

    private void BallStart()
    {
        //create new vector to hold position of the paddle
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        //now change the position of the ball to the paddle's with the paddleDistVect
        transform.position = paddlePosition + paddleDistVect;
    }

    private void OnCollisionEnter2D(Collision2D collision) //create a method to activate on collision
    {
        Vector2 veloChange = new Vector2(
                            Random.Range(0f, randomFactor), 
                            Random.Range(0f, randomFactor)); //for randomFactor moving of ball
        if (hasStarted) //if the game has started
        {
            //assign clip to a random sound from the array
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           
            //note: PlayOneShot makes it to where the audio plays all the way through and never gets interupted
            ballAudio.PlayOneShot(clip, volume); //plays the audio source found on Ball

            myRigidBody2D.velocity += veloChange; //changes the velocity of ball to avoid forever bouncing loops
        }

    }
}

