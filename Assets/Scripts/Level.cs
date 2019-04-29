using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    //config
    [SerializeField] int breakableBlocks; //serial for debugging
    int currentSceneIndex; //used to keep track of the player's progress while jumping between levels and story scene

    //class references
    SceneLoader loader;  //Sceneloader class reference
    GameSession game;

    public void Start()
    {
        loader = FindObjectOfType<SceneLoader>(); //reference the values of loader when the code starts
    }

    //each time this method is called, it adds to the number of breakable Blocks in the level
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    //each time a block is destroyed by the player, it should remove it from the number of blocks
    public void BlockDestroyed()
    {
        breakableBlocks--;
        
        //then check if the number of breakable blocks have reached zero (win condition)
        if (breakableBlocks <= 0)
        {
            //loader.LoadNextScene(); //call LoadNextScene() from Sceneloader
            loader.LoadStoryState(); //call to load story scene
        }
    }
}
