using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //variables
    int currentSceneIndex;

    //config
    //[SerializeField] GameObject storyState;
    //[SerializeField] GameObject gameState;
    [SerializeField] StoryScene storyStateObject;

    //references
    GameSession game;
    //StoryScene storyStateObject;

    private void Awake()
    {
        game = FindObjectOfType<GameSession>();
        //storyStateObject = FindObjectOfType<StoryScene>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        //storyState = GameObject.Find("storyState");
    }

    //loads the next scene
    public void LoadNextScene()
    {
        storyStateObject.gameObject.SetActive(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        SceneManager.LoadScene(currentSceneIndex + 1); //loads the next scene after this current one
        
    }
    //loads the story scene and returns the player's level progression
    public void LoadStoryState()
    {
        storyStateObject.gameObject.SetActive(true);
        //SceneManager.LoadScene(1); //1 should be the build index of the storyScene from the project build settings

    }

    //returns the user to the starting scene
    public void ReturntoStart()
    {
        SceneManager.LoadScene(0); //loads the beginning scene

        //delete gameStatus to restart
        FindObjectOfType<GameSession>().resetGame(); //Must remember that calling functions from other classes isn't the same a c++
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit(); //quits the game
    }
}
