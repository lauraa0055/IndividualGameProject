using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    private Vector2 screenBounds;
    private int makeNumberPositive = -1;
    // Start is called before the first frame update
    void Start()
    {

        //Purpose of following code: Constraining user to only the screen size/camera

        //What it does: gets X and Y variables
        //Which are half of the screen width + half of screen height
        //note: the variables are negative because of worldPoint
        //Camera =  device through which the player views the world
        //Camera.main = The first enabled Camera component that is tagged "MainCamera"
        //ScreenToWorldPoint = Transforms a point from screen space into world space, where world space is defined
        //as the coordinate system at the very top of your game's hierarchy. 
        //Taken from Unity: 
        // - https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
        // - https://docs.unity3d.com/ScriptReference/Camera.html

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    //call this because usually this happens after movement 
    void LateUpdate()
    {
        //we do this to alter object x and y position
        Vector3 viewPos = transform.position;

        //Clamp = restrict a number between two numbers
        //Mathf.Clamp = clamps the given value between a range defined by the given minimum integer and maximum integer values.

        //(current x position to screen x position.
        //use minimum to be negative,
        //reverse the value to make it the maximum value)
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * makeNumberPositive);

        //(current y position to screen y position.
        //use minimum to be negative,
        //reverse the value to make it the maximum value)
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * makeNumberPositive);

        //position is equal to altered position
        transform.position = viewPos;
    }
}
