using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject[] pauseMode;
    [SerializeField] GameObject playMode;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1.0f;

        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");

        //makes buttons to show in pause mode not show
        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        //pauses the game
        Time.timeScale = 0.0f;

        //makes buttons to be shown in pause mode shown, and buttons shown in play mode not shown
        foreach (GameObject g in pauseMode)
            g.SetActive(true);

      
            playMode.SetActive(false);

            Debug.Log(playMode.activeSelf);
       
            
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        //makes buttons to be shown in play mode be showm. and buttons shown in pause mode not be shown
        foreach (GameObject g in pauseMode)
            g.SetActive(false);

            playMode.SetActive(true);
    }

    public void LoadMenu()
    {
        //loads Menu/Start Scene
        SceneManager.LoadScene("mainMenuScene");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("settingsScene");
    }

}
