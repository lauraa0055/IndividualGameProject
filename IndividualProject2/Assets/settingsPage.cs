using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsPage : MonoBehaviour
{
    GameObject backToGame;
    GameObject backToMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        backToGame = GameObject.FindGameObjectWithTag("ShowAfterGameStart");
        backToMenu = GameObject.FindGameObjectWithTag("ShowBeforeGameStart");

        if (PersistentData.Instance.GetScene() == 0)
        {
            backToMenu.SetActive(true);
            backToGame.SetActive(false);
        }

        else
        {
            backToMenu.SetActive(false);
            backToGame.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadMenu()
    {
        //loads Menu/Start Scene
        SceneManager.LoadScene("mainMenuScene");
    }

    public void LoadBackToGame()
    {
        SceneManager.LoadScene(PersistentData.Instance.GetScene());
    }
}
