using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //video used to help with bullets
    //https://youtu.be/4KoAlJ8sPy4

    [SerializeField] GameObject controller;

    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
