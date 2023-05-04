using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    GameObject[] nextLevelObjects;
    GameObject[] pauseMode;
    GameObject[] playMode;

    public static NextLevel NextSceneScreen;

    private void Awake()
    {
        if (NextSceneScreen == null)
        {
            DontDestroyOnLoad(this);
            NextSceneScreen = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        nextLevelObjects = GameObject.FindGameObjectsWithTag("ShowAfterDestroyedBalloon");
        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");

        foreach (GameObject g in nextLevelObjects)
            g.SetActive(false);


    }

    public void GoToNextLevelScreen()
    {
        Time.timeScale = 0.0f;

        foreach (GameObject g in nextLevelObjects)
            g.SetActive(true);

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(false);
    }

    public void AdvanceScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("HighScoresScene");
        }

        foreach (GameObject g in nextLevelObjects)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
