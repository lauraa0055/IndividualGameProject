using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] int score;
    const int DEFAULT_POINTS = 1;
    [SerializeField] Text scoreText;
    [SerializeField] Text nameOfPlayer;
    [SerializeField] float waitForAudioClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        PersistentData.Instance.SetScene(SceneManager.GetActiveScene().buildIndex);
        DisplayScore();
        DisplayName();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void DisplayName()
    {
        nameOfPlayer.text = PersistentData.Instance.GetName();
    }    

}
