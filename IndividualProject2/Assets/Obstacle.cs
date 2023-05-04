using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Rigidbody2D squareBody;
    private float horizontalMovement;
    private float constantMovement = .09f;
    float SPEED = 1.9f;
    float min_x = -13.6f;

    // Start is called before the first frame update
    void Start()
    {
        if(squareBody == null)
            squareBody = GetComponent<Rigidbody2D>();

        horizontalMovement = squareBody.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveLeft();
    }

    private void moveLeft()
    {
        if(squareBody.position.x >= min_x)
        {
            horizontalMovement -= constantMovement;
            squareBody.position = new Vector2(horizontalMovement * SPEED, squareBody.position.y);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
