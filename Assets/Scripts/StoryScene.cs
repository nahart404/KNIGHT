using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used for displaying story text element scene as well as loading next game
public class StoryScene : MonoBehaviour
{

    //class references
    SceneLoader loader;  //Sceneloader class reference

    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<SceneLoader>(); //reference the values of loader when the code starts
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loader.LoadNextScene(); //call LoadNextScene() from Sceneloader
        }
    }
}
