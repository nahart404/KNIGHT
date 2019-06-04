using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChanger : MonoBehaviour
{
    //var
    string blockType;
    float timerDuration = 2f; //for color changing
    float centerTimerDuration = 3f;

    float newLeftTimer;
    float newRightTimer;

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
    }

    // Update is called once per frame
    void Update()
    {
        ColorChangeSorter(blockType);
    }

    //method used to help decipher which blocks change when
    public void ColorChangeSorter(string type)
    {
        switch (type)
        {
            case "left":
                LeftChanger();
                break;

            case "right":
                RightChanger();
                break;

            default:
                break;
        }
    }

    private void LeftChanger()
    {
        //sprite renderer component and colors used
        var getColor = GetComponent<SpriteRenderer>().color;
        var red = new Color(0.9622642f, 0.1134745f, 0.1134745f);
        var pink = new Color(0.9433962f, 0.4850481f, 0.4850481f);

        if (Time.time > newLeftTimer && getColor == pink) //if timer's up AND block is still pink,
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9622642f, 0.1134745f, 0.1134745f);
            //the red color from the eye's pupils

            //create new timer with duration of color change and game time
            newLeftTimer = timerDuration + Time.time;
            Debug.Log(newLeftTimer);

        }
        //change color back with new timer duration
        if (Time.time > newLeftTimer)
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9433962f, 0.4850481f, 0.4850481f);
            //normal eye color

            //create new timer with duration of color change and game time
            newLeftTimer = timerDuration + Time.time;
        }
    }

    private void RightChanger()
    {
        //sprite renderer component and colors used
        var getColor = GetComponent<SpriteRenderer>().color;
        var red = new Color(0.9622642f, 0.1134745f, 0.1134745f);
        var pink = new Color(0.9433962f, 0.4850481f, 0.4850481f);

        if (Time.time > newRightTimer && getColor == pink) //if timer's up AND block is still pink,
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9622642f, 0.1134745f, 0.1134745f);
            //the red color from the eye's pupils

            //create new timer with duration of color change and game time
            newRightTimer = timerDuration + Time.time;
            Debug.Log(newRightTimer);

        }
        //change color back with new timer duration
        if (Time.time > newRightTimer)
        {
            //change color
            GetComponent<SpriteRenderer>().color = new Color(0.9433962f, 0.4850481f, 0.4850481f);
            //normal eye color

            //create new timer with duration of color change and game time
            newRightTimer = timerDuration + Time.time;
        }
    }
}
