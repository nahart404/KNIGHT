using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChanger : MonoBehaviour
{
    //var
    string blockType;

    /*
     Since Time.time messes up due to the fact that the player starts on the Start menu, not Lvl 1,
     float timer will be used as a makeshift timer for when Lvl 1 starts*/
    float timer = 0f; //will be used to replace the system timer (Time.time)  
    
    float timerDuration = 2f; //for color changing
    float centerTimerDuration = 3f;

    float newLeftTimer;
    float newRightTimer;

    Vector2 blockOrigin = new Vector2(); //origin positioning of the block (used for teeth)

    //class references
    Block block;
    // Start is called before the first frame update
    void Start()
    {        
        //get the "type" from Block class
        block = gameObject.GetComponent<Block>();
        blockType = block.type;

        newLeftTimer = timerDuration;
        newRightTimer = timerDuration * 2; //right side always needs to start with double of left's timer

        //set origin
        blockOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + .05f; //inc timer
        ColorChangeSorter(blockType);
    }

    //method used to help decipher which blocks change when
    public void ColorChangeSorter(string type)
    {
        Debug.Log(type);
        switch (type)
        {
            case "left": //eyes
                LeftChanger();
                break;

            case "right": //eyes
                RightChanger();
                break;

            case "top": //mouth
                MouthTop();
                break;

            case "bottom": //mouth
                MouthBottom();
                break;

            default:
                break;
        }
    }
    /*Following methods are for the eyes
     */
    private void LeftChanger()
    {
        //sprite renderer component and colors used
        var getColor = GetComponent<SpriteRenderer>().color;
        var red = new Color(0.9622642f, 0.1134745f, 0.1134745f);
        var pink = new Color(0.9433962f, 0.4850481f, 0.4850481f);

        if (timer > newLeftTimer && getColor == pink) //if timer's up AND block is still pink,
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9622642f, 0.1134745f, 0.1134745f);
            //the red color from the eye's pupils

            //create new timer with duration of color change and game time
            newLeftTimer = timerDuration + timer;

        }
        //change color back with new timer duration
        if (timer > newLeftTimer)
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9433962f, 0.4850481f, 0.4850481f);
            //normal eye color

            //create new timer with duration of color change and game time
            newLeftTimer = timerDuration + timer;
        }
    }

    private void RightChanger()
    {
        //sprite renderer component and colors used
        var getColor = GetComponent<SpriteRenderer>().color;
        var red = new Color(0.9622642f, 0.1134745f, 0.1134745f);
        var pink = new Color(0.9433962f, 0.4850481f, 0.4850481f);

        if (timer > newRightTimer && getColor == pink) //if timer's up AND block is still pink,
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9622642f, 0.1134745f, 0.1134745f);
            //the red color from the eye's pupils

            //create new timer with duration of color change and game time
            newRightTimer = timerDuration + timer;

        }
        //change color back with new timer duration
        if (timer > newRightTimer)
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9433962f, 0.4850481f, 0.4850481f);
            //normal eye color

            //create new timer with duration of color change and game time
            newRightTimer = timerDuration + timer;
        }
    }

    /*Following methods are for the mouth
     */ 
     private void MouthTop()
    {
        Vector2 teethSpaceTop;
        //create if statement to check positioning first and move the blocks accordingly
        if (blockOrigin.y < transform.position.y)
        {
            //create new position
            teethSpaceTop = new Vector2(transform.position.x, transform.position.y + 1f);
            transform.position = teethSpaceTop;
        }
        
    }

    private void MouthBottom()
    {

    }
}
