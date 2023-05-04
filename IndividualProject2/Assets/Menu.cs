using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] InputField playerNameInput;

    private void Start()
    {
       playerNameInput.text = PersistentData.Instance.GetName();
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
