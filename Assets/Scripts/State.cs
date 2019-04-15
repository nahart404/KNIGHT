using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    //(x, y) x= min area, y= num of lines before scrolling
    [TextArea(10,14)][SerializeField] string storyText;
    [SerializeField] State[] nextStates; //everything after the first state

    //returns the story text when called
    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    /*public State[] GetAllStates()
    {
        return states;
    }*/
}
