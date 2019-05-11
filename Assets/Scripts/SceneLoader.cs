using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //variables
    int currentSceneIndex;

    //config
    [SerializeField] StoryScene storyStateObject;

    //references
    GameSession game;

    private void Awake()
    {
        game = FindObjectOfType<GameSession>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
    }

    //loads the next scene
    public void LoadNextScene()
    {
        //storyStateObject.gameObject.SetActive(false); //set back to false to hide it
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        SceneManager.LoadScene(currentSceneIndex + 1); //loads the next scene after this current one
        
    }
    //loads the story scene and returns the player's level progression
    public void ShowStoryState()
    {
        storyStateObject.gameObject.SetActive(true); //show story state
    }

    //returns the user to the starting scene
    public void ReturntoStart()
    {
        SceneManager.LoadScene(0); //loads the beginning scene

        //delete gameStatus to restart
        FindObjectOfType<GameSession>().resetGame(); //Must remember that calling functions from other classes isn't the same a c++
    }

    public StoryScene GetStoryStateObject()
    {
        return storyStateObject;
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit(); //quits the game
    }
}
