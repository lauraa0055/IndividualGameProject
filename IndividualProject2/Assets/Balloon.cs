using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{

    Rigidbody2D balloonBody;
    float horizontalMovement;
    float constantMovement = .09f;
    float SPEED = 1.9f;
    bool isFacingRight = true;
    float max_x = 13.6f;
    float min_x = -13.6f;
    float ballonPositionY = 5.19f;

    GameObject controller;

    private Vector3 localScaleChange = new Vector3(+0.0001f, +0.0001f, 0f);
    private const float afterTheseSecondsIncreaseBy = 5f;
    private const float increaseByEverySecond = 15f;
    private const int timeOfInflate = 60;

    //score
    //const int mediumBalloonPointsSeconds = 593;
    const int mediumBalloonPointsSeconds = 5;
    const int mediumBalloonPoints = 2;
    //const int largeBalloonPointsSeconds = 1230;
    const int largeBalloonPointsSeconds = 15;
    const int largeBalloonPoints = 3;
    //const int popBalloon = 1299;
    const int popBalloon = 30;
    [SerializeField] float seconds = 0;

    //audio
    [SerializeField] AudioSource audio;

    //keeping track of scenes to change speed
    int scene;
    int goToNextScene = 1;
    int sceneOne = 1;
    int sceneTwo = 2;
    int sceneThree = 3;
    int gameFinishToHighScores = 6;


    // Start is called before the first frame update
    void Start()
    {
        if (balloonBody == null)
            balloonBody = GetComponent<Rigidbody2D>();

        horizontalMovement = balloonBody.position.x;

        if(controller == null)
            controller = GameObject.FindGameObjectWithTag("GameController");

        scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(scene);
        
        if(scene == sceneOne)
        {
            PersistentData.Instance.SetScore(0);
        }

        if(scene == sceneTwo)
        {
            SPEED = 3.5f;
        }
        
        if(scene == sceneThree)
        {
            SPEED = 5.5f;
        }

        if(audio == null)
            audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isFacingRight)
            moveRight();

        if (!isFacingRight)
            moveLeft();

        InvokeRepeating("InflateBalloon", afterTheseSecondsIncreaseBy, increaseByEverySecond);
        //Debug.Log("X: " + transform.localScale.x + " | Y: " + transform.localScale.y + " | Seconds" + seconds);
    }

    private void moveRight()
    {
        if (balloonBody.position.x <= max_x)
        {
            horizontalMovement += constantMovement;
            balloonBody.position = new Vector2(horizontalMovement * SPEED, ballonPositionY);
            //Debug.Log(balloonBody.position.x + " Y: " + balloonBody.position.y);
            //InflateBalloon();
        }
        else
        {
            isFacingRight = !isFacingRight;
        }
    }

    private void moveLeft()
    {
        if (balloonBody.position.x >= max_x || !isFacingRight && balloonBody.position.x >= min_x)
        {
            horizontalMovement -= constantMovement;
            balloonBody.position = new Vector2(horizontalMovement * SPEED, ballonPositionY);
            //Debug.Log(balloonBody.position.x + " Y: " + balloonBody.position.y);
            //InflateBalloon();
        }
        else
        {
            isFacingRight = !isFacingRight;
        }
    }

    private void InflateBalloon()
    {
        transform.localScale += localScaleChange;
        seconds += Time.deltaTime;

        if (seconds > popBalloon)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(scene);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //controller.GetComponent<ScoreKeeper>().AddPoints();

        if(collision.gameObject.tag == "Bullet")
        {

            //593 = medium
            //1230 = large
            if(seconds < mediumBalloonPointsSeconds)
            {
                //AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                controller.GetComponent<ScoreKeeper>().AddPoints();
            }
                

           else if(seconds >= mediumBalloonPointsSeconds && seconds < largeBalloonPointsSeconds)
            {
                controller.GetComponent<ScoreKeeper>().AddPoints(mediumBalloonPoints);
            }

           else if(seconds >= largeBalloonPointsSeconds && seconds < popBalloon)
            {
                controller.GetComponent<ScoreKeeper>().AddPoints(largeBalloonPoints);
            }

            AudioSource.PlayClipAtPoint(audio.clip, transform.position);

            Destroy(gameObject);

            Destroy(collision.gameObject);

            NextLevel.NextSceneScreen.GoToNextLevelScreen();

        }
           
    }

}