using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Script used for displaying story text element scene as well as loading next game
public class StoryScene : MonoBehaviour
{
    //config
    [SerializeField] TextMeshProUGUI textComponent; //Text is from the UnityEngine.UI namespace
    [SerializeField] State[] allStates; //array of states

//class references
    SceneLoader loader;  //Sceneloader class reference
    State state;
    GameSession game;

   
    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<SceneLoader>(); //reference the values of loader when the code starts
        game = FindObjectOfType<GameSession>();

        //then set up the current state and get story text from it
        state = allStates[game.GetCurrentState()];
        //state = startingState;
        textComponent.text = state.GetStateStory();

}

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*problem: currentSceneIndex and currentStateIndex are not exactly the same. (scene should be 1 more
         than state) and that causes a problem with transition to the correct scene after the correct state
         */

            loader.LoadNextScene(game.GetCurrentState() + 1); //call LoadNextScene() from Sceneloader
            ManageState(); //set up the next scenes/states
        }
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates(); //gets value from State class's method

        //inc state index by one
        game.GetNextState();
        
        textComponent.text = state.GetStateStory(); //update text for when state has changed
    }
}
