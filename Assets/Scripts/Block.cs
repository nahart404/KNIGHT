using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config
    [SerializeField] AudioClip breakingSound;
    [SerializeField] float volume = .04f; //set the volume

    //references to other classes !!!Don't forget to assign values to references (FindObjectOfType<>())!
    Level level;
    //GameStatus status;

    public void Start()
    {
        //find and assign what level is
        level = FindObjectOfType<Level>();

        //update number of blocks from the Level class reference
        level.CountBreakableBlocks();
    }
    //destory block when ball collides with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        /* This puts breakingSound on each block broken; I thought it was cool
                * but we need to place it on the camera for the tutorial to make it an even sound
                * //config for gameObject
                float xPos = gameObject.transform.position.x;
                float yPos = gameObject.transform.position.y;

                Vector3 blockPos = new Vector3(xPos, yPos, 0);*/

        //play the breaking sound before deleting the object; hearing from the Camera
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position, volume);

        //find and assign what status is
        //status = FindObjectOfType<GameStatus>(); 
        //add points since the player destroyed the block
        //status.addToScore();
        //!!!!!Another way without class cache reference is this:
        FindObjectOfType<GameStatus>().addToScore();

        Destroy(gameObject); //destroys the object in that running of the game

        //now call method to remove 1 from the block counter (in Level class)
        level.BlockDestroyed();

        
    }
}
