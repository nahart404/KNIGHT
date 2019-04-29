using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //config
    [Range(.1f, 10f)] [SerializeField] float gameSpeed = 1f;  //1f is normal speed with a range of .1-10
    [SerializeField] int pointsPerBlock = 1; //1 for now, not sure I want points
    [SerializeField] TextMeshProUGUI scoreText;

    //game state variables  (like score)
    [SerializeField] int currentScore = 0; //score should change via the player breaking blocks
    [SerializeField] int currentState = 0; //will always start at 0 to represent the Openning state
    [SerializeField] int tempScene = 0; //a holder vairable to keep track of what scene/level the player left off on
    int currentScene;

    private void Awake() //method runs before start (look up unity execution order)
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; //finds the number of game statuses running

        //if there's more then one, delete this instance of gameStatus object
        if (gameStatusCount > 1)
        {
            /*glitch happening where Destroy() doesn't happen until the very end of the
             unity execution so for a split sec, there are two GameStatus objects running and the program
             freaks out. The bug fix happens in lect 76*/
            gameObject.SetActive(false); //bug fix
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); //don't destroy object
        }
    }
    void Start()
    {
        //display the current score
        displayScore();
    }


    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
        //speed of game
        Time.timeScale = gameSpeed;
    }

    //method to add to the player's score (will be used in block script)
    public void addToScore()
    {
        currentScore += pointsPerBlock; //add
        displayScore();
    }

    //displays score for user to see
    public void displayScore()
    {
        scoreText.text = currentScore.ToString();
    }

    //destroy gameStatus when called (used for when gameover happens)
    public void resetGame()
    {
        Destroy(gameObject);
    }
    /*public void setTempScene()
    {
        tempScene = currentScene;
    }*/

    //next two methods are for keeping track of the current story state and scene the player is on
    public int GetNext()
    {
        currentState++; //inc next
        //int totalScenes = SceneManager.sceneCountInBuildSettings;
        tempScene = tempScene + currentState;
        return tempScene;
    }

    /*public int GetCurrentState()
    {
        if (tempScene > 1)
        { 
            currentState = tempScene - 1;
            Debug.Log("I am here");
        }
        
        return currentState;
    }*/
}
