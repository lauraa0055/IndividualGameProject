using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    GameObject[] nextLevelObjects;
    GameObject[] pauseMode;
    [SerializeField] GameObject[] playMode;

    [SerializeField] Text score;

    public static NextLevel NextSceneScreen;

    // Start is called before the first frame update
    void Start()
    {

        if (NextSceneScreen == null)
            NextSceneScreen = this;
        

        /**/nextLevelObjects = GameObject.FindGameObjectsWithTag("ShowAfterDestroyedBalloon");
        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");/**/

        /**/foreach (GameObject g in nextLevelObjects)
            g.SetActive(false);/**/

    }

    public void GoToNextLevelScreen()
    {
        Time.timeScale = 0.0f;

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(false);
        
        foreach (GameObject g in nextLevelObjects)
            g.SetActive(true);

        score.text = "Score: " + (PersistentData.Instance.GetScore()).ToString();

    }

    public void AdvanceScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            PersistentData.Instance.SetScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("HighScoresScene");
        }

        foreach (GameObject g in nextLevelObjects)
            g.SetActive(false);
    }

    /*public void LoadMenu()
    {
        //loads Menu/Start Scene
        SceneManager.LoadScene("mainMenuScene");
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
