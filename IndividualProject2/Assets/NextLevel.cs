using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    GameObject[] nextLevelObjects;
    GameObject[] pauseMode;
    [SerializeField] GameObject[] playMode;
    bool shown = false;

    public static NextLevel NextSceneScreen;

    // Start is called before the first frame update
    void Start()
    {
        shown = true;

        if (NextSceneScreen == null)
            NextSceneScreen = this;
        

        /**/nextLevelObjects = GameObject.FindGameObjectsWithTag("ShowAfterDestroyedBalloon");
        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");/**/

        /**/foreach (GameObject g in nextLevelObjects)
            g.SetActive(false);/**/

    }

    public bool getShown()
    {
        return shown;
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
