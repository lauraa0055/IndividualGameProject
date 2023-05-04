using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    //x: 15.14
    //y: -4.98
    //helped with spawning: https://answers.unity.com/questions/398607/spawn-after-every-5-seconds.html

    private float spawnTimeFirst = 3f;
    private float spawnTimeSecond = 9f;

    [SerializeField] GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSquareObstacle", spawnTimeFirst, spawnTimeSecond);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnSquareObstacle()
    {
        GameObject.Instantiate(square);
    }

}
