using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //loads the next scene when user clicks button on UI
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        SceneManager.LoadScene(currentSceneIndex + 1); //loads the next scene after this current one
    }

    //returns the user to the starting scene
    public void ReturntoStart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //gets the scene index to use
        SceneManager.LoadScene(0); //loads the beginning scene
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit(); //quits the game
    }
}
