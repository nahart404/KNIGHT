using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
    }

    //loads the next scene
    public void LoadNextScene(int currentSceneIndex)
    {
        /*problem: currentSceneIndex and currentStateIndex are not exactly the same. (scene should be 1 more
         than state) and that causes a problem with transition to the correct scene after the correct state
         */
    
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        SceneManager.LoadScene(currentSceneIndex + 1); //loads the next scene after this current one
        
    }
    //loads the story scene and returns the player's level progression
    public void LoadStoryScene()
    {
        SceneManager.LoadScene(1); //1 should be the build index of the storyScene from the project build settings
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
