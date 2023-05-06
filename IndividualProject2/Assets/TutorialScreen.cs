using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    GameObject[] playMode;
    GameObject[] tutorial;
    GameObject[] nextLevelObjects;
    GameObject player;
    GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");
        nextLevelObjects = GameObject.FindGameObjectsWithTag("ShowAfterDestroyedBalloon");
        tutorial = GameObject.FindGameObjectsWithTag("tutorial");

        player = GameObject.FindGameObjectWithTag("Player");
        balloon = GameObject.FindGameObjectWithTag("Balloon_Target");

        player.SetActive(false);
        balloon.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(false);

        foreach (GameObject g in nextLevelObjects)
            g.SetActive(false);

        foreach (GameObject g in tutorial)
            g.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitTutorialButton()
    {
        foreach (GameObject g in tutorial)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(true);

        player.SetActive(true);
        balloon.SetActive(true);

        Time.timeScale = 1.0f;
    }
}
