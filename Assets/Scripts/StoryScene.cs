using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Script used for displaying story text element scene as well as loading next game
public class StoryScene : MonoBehaviour
{
    //config
    [SerializeField] TextMeshProUGUI textComponent; //Text is from the UnityEngine.UI namespace
    [SerializeField] State currentState;//of type "State"


//class references
SceneLoader loader;  //Sceneloader class reference
State state;

// Start is called before the first frame update
void Start()
    {
        loader = FindObjectOfType<SceneLoader>(); //reference the values of loader when the code starts

        //set up start state and get story text from it
        state = currentState;
        textComponent.text = state.GetStateStory();
}

    // Update is called once per frame
    void Update()
    {
           
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loader.LoadNextScene(); //call LoadNextScene() from Sceneloader
            ManageState(); //set up the next scenes/states
        }
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates(); //gets value from State class's method

        //for loop to fix array out of bounds (player choosing a choice that isn't used in a state)
        /*for (int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) // + i changes the key code for each loop
            {
                state = nextStates[i]; //changes the access state as well. mind blown
            }
        }*/
        //state = nextStates[0]; //changes the access state as well. mind blown
        textComponent.text = state.GetStateStory(); //update text for when state has changed
    }
}
