using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorChain : MonoBehaviour
{
    /* script used to anchor first chain in the line to the moving paddle
     */
    //config
    [SerializeField] Paddle paddle1;
    [SerializeField] Ball ball1;
    [SerializeField] Sprite chainSprite; //the sprite to use

    //variables
    //Vector2 paddlePosition;
    //Vector2 ballPosition;
    //Vector2 dist; //distance between ball and paddle
    Vector2 currentPosition;


    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform.position; //get current position of the sprite object

    }

    // Update is called once per frame
    void Update()
    {
        //paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); //pos of paddle
        //ballPosition = new Vector2(ball1.transform.position.x, ball1.transform.position.y); //pos of ball
        //dist = ballPosition - paddlePosition;

        currentPosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); //new chain position
        transform.position = currentPosition;


    }
}
