using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidth = 16f; //how wide the screen is (using Unity units)
    //f ensures that 16 is of type float
    [SerializeField] float minX = 1f; //min of where the mouse can move on x axis (with paddle length in mind)
    [SerializeField] float maxX = 15f; //max of where the mouse can move on x axis

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Use this method to have a constant update of info (positioning, frames, etc.)
    void Update()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidth; //position of x axis of mouse on the screen only to console

        //move paddle with the mouse using Vector2 (move it on the x axis)
        Vector2 paddlePosition = new Vector2 (transform.position.x, transform.position.y);
        //Input.mousePosition.x / Screen.width * screenWidth has the position of the mouse on the screen using only the x axis
        //transform.position.y keeps the paddle from moving on the y axis(keeps it where it is)

        //now need to limit where the mouse can and can't be on the screen
        paddlePosition.x = Mathf.Clamp(mousePosition, minX, maxX);

        //move to the position
        transform.position = paddlePosition;
    }
}
