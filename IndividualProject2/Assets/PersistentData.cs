using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] int currentScene;
    bool finishedScene3 = false;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
        if (currentScene == 3)
            finishedScene3 = true;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void SetScene(int scene)
    {
        currentScene = scene;
    }

    public int GetScene()
    {
        return currentScene;
    }

    public bool getFinishedScene3()
    {
        return finishedScene3;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
