﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config
    [SerializeField] AudioClip breakingSound;
    [SerializeField] float volume = .04f; //set the volume
    [SerializeField] GameObject blockParticlesVFX;
    [SerializeField] int maxHits; //max hits certain blocks take before breaking

    //references to other classes !!!Don't forget to assign values to references (FindObjectOfType<>())!
    Level level;

    //state varaibles
    int timesHit;

    public void Start()
    {
        CountBlocks(); /*assigns level and counts the number of breakable blocks that the player
                        needs to destroy in the level to move on to the next*/
    }

    private void CountBlocks()
    {
        //find and assign what level is
        level = FindObjectOfType<Level>();

        if (tag == "Breakable" || tag == "MultiHit")//if assigned tag of block is "breakable" OR "MultiHit"
        {
            //update number of blocks from the Level class reference
            level.CountBreakableBlocks();
        }
    }

    //action taken when ball collides with a type of block
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    //handles what happens when the ball hits the different types of blocks using tags
    private void HandleHit()
    {
        if (tag == "MultiHit") //if it's a "MultiHit" block
        {
            //inc the timesHit
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyBlock(); //destroy
            }
        }
        else if (tag == "Breakable")//if assigned tag of block is "breakable" 
        {  
                DestroyBlock(); //destroy
        }
    }

    private void DestroyBlock()
    {
       PlayDestorySFX();

       TriggerBlockVFX(); //call to add particle effect
       Destroy(gameObject); //destroys the object in that running of the game

       //now call method to remove 1 from the block counter (in Level class)
       level.BlockDestroyed();
    }

    private void PlayDestorySFX()
    {
        /* This puts breakingSound on each block broken; I thought it was cool
                        * but we need to place it on the camera for the tutorial to make it an even sound
                        * //config for gameObject
                        float xPos = gameObject.transform.position.x;
                        float yPos = gameObject.transform.position.y;

                        Vector3 blockPos = new Vector3(xPos, yPos, 0);*/

        //play the breaking sound before deleting the object; hearing from the Camera
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position, volume);

        
        //!!!!!Another way without class cache reference is this:
        FindObjectOfType<GameSession>().addToScore(); //adds to player score
    }

    private void TriggerBlockVFX()
    {
        GameObject sparkles = Instantiate(blockParticlesVFX, transform.position, transform.rotation);
        //both position and rotation refer to this instance of a block's transform

        //then destroy it once done
        Destroy(sparkles, 1f); //destory after 1 sec
    }
}
