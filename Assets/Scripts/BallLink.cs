using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLink : MonoBehaviour
{
    /*Script used to link the last chain link of the group to the ball to avoid the strange physics bug after 
     * reseting a level
     */ 
    //config
    [SerializeField] Ball ball1;

    //variables
    Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector2(ball1.transform.position.x, ball1.transform.position.y); //new chain position
        transform.position = currentPosition;
    }
}
