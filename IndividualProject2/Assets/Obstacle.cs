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

        if (PersistentData.Instance.GetScene() == 2)
            squareBody.transform.localScale = new Vector2(5, 5);
        else
            squareBody.transform.localScale = new Vector2(1, 1);

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Destroy(collision.gameObject);

        if (collision.gameObject.tag == "wallLeft")
            Destroy(gameObject);
    }

    private void moveLeft()
    {
        horizontalMovement -= constantMovement;
        squareBody.position = new Vector2(horizontalMovement * SPEED, squareBody.position.y);
    }

}
