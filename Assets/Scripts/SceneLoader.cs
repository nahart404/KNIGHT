using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    //loads the next scene
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        SceneManager.LoadScene(currentSceneIndex + 1); //loads the next scene after this current one
        
    }

    //returns the user to the starting scene
    public void ReturntoStart()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
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
