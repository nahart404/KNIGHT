using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLabel : MonoBehaviour
{
    //config
    [SerializeField] Sprite[] LabelSprites; //array of sprites for blocks that need more than one hit to 

    //var
   // int spriteIndex; //used fro the sprite array

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //makes the sprite renderer in unity display a new sprite from the array
    public void ShowNextSprite(int spriteIndex)
    {
        //some code to protect against a null in the array index
        if (LabelSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = LabelSprites[spriteIndex];
        }
        else //show that there's something wrong
        {
            Debug.LogError("Something went wrong with the sprite array" + gameObject.name);
        }
    }
}
