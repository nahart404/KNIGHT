using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!DON'T NEED THIS SCRIPT
    //config
    //need both paddle and ball class
    [SerializeField] Paddle paddle1;
    [SerializeField] GameObject lastChain; //the cahin object before this one
    [SerializeField] Sprite chainSprite;

    //variables
    Vector2 LastChainPosition;
    Vector2 currentPosition;
    
    float spriteLength; //length of 1 sprite

    
    // Start is called before the first frame update
    void Start()
    {
        spriteLength = chainSprite.bounds.size.y; //the length of sprite
        currentPosition = gameObject.transform.position; //get current position of the sprite object
        //currentPosition = new Vector2(paddle1.transform.position.x, lastChain.transform.position.y + spriteLength / 2);
    }

    // Update is called once per frame
    void Update()
    {
        //LastChainPosition = new Vector2(lastChain.transform.position.x, lastChain.transform.position.y); //last position

        Vector2 newChainPosition = new Vector2(lastChain.transform.position.x, lastChain.transform.position.y + spriteLength/2); //new chain position
        gameObject.transform.position = newChainPosition;

        //drawSprite(dist);
                
    }
}
