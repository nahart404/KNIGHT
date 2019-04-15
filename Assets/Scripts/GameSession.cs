using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config
    [Range(.1f, 10f)] [SerializeField] float gameSpeed = 1f;  //1f is normal speed with a range of .1-10
    [SerializeField] int pointsPerBlock = 1; //1 for now, not sure I want points
    [SerializeField] TextMeshProUGUI scoreText;

    //game state variables  (like score)
    [SerializeField] int currentScore = 0; //score should change via the player breaking blocks
    [SerializeField] int currentState = 0; //will always start at 0 to represent the Openning state

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

    //next two methods are for keeping track of the current story state the player is on
    public int GetNextState()
    {
        currentState++; //inc next
        return currentState;
    }
    public int GetCurrentState()
    {
        return currentState;
    }
}
