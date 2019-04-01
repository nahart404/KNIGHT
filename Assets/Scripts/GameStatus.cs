using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config
    [Range(.1f, 10f)] [SerializeField] float gameSpeed = 1f;  //1f is normal speed with a range of .1-10
    [SerializeField] int pointsPerBlock = 1; //1 for now, not sure I want points
    [SerializeField] TextMeshProUGUI scoreText;

    //game state variables  (like score)
    [SerializeField] int currentScore = 0; //score should change via the player breaking blocks

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
}
