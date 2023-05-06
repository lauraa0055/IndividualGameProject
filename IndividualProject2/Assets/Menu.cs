using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] InputField playerNameInput;
    GameObject backToGame;
    GameObject menu;

    private void Start()
    {
       playerNameInput.text = PersistentData.Instance.GetName();

       backToGame = GameObject.FindGameObjectWithTag("ShowAfterGameStart");
       menu = GameObject.FindGameObjectWithTag("ShowBeforeGameStart");

       if (PersistentData.Instance.GetScene() == 0 || (PersistentData.Instance.GetScene() == 3 && PersistentData.Instance.getFinishedScene3()))
       {
         menu.SetActive(true);
         backToGame.SetActive(false);
       }
       else
       {
         menu.SetActive(false);
         backToGame.SetActive(true);
       }

    }

    //start game
    public void StartGame()
    {
        //Debug.Log(playerNameInput.text);
        string playerName = playerNameInput.text;
        PersistentData.Instance.SetName(playerName);
        SceneManager.LoadScene("scene1");
        //Debug.Log("pressed start game button");
    }

    public void LoadBackToGame()
    {
        SceneManager.LoadScene(PersistentData.Instance.GetScene());
    }


    public void Tutorial()
    {
        SceneManager.LoadScene("tutorialScene");
        Debug.Log("pressed tutorial button");
    }

    public void Settings()
    {
        SceneManager.LoadScene("settingsScene");
        Debug.Log("pressed settings button");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("HighScoresScene");
    }
}
