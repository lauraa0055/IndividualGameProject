using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class User : MonoBehaviour
{
    //GetKey Information: https://docs.unity3d.com/ScriptReference/Input.GetKey.html

    Rigidbody2D user;
    float movementHorizontal;
    const float SPEED = 15f;
    bool isGrounded = true;
    bool jumpPressed = false;
    float jumpForce = 500f;
    bool isFacingRight = true;
    const float max_x = 13.6f;
    const float min_x = -13.6f;

    //bullet
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float BULLET_SPEED = 10f;

    //when hit by square
    int scene;

    //animator
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        if (user == null)
            user = GetComponent<Rigidbody2D>();

        scene = SceneManager.GetActiveScene().buildIndex;
    }



    // Update is called once per frame
    void Update()
    {
        //Check input from user to move left or right
        movementHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("SPEED", Mathf.Abs(movementHorizontal));

        //uses the spacebar to jump
        if (Input.GetKey(KeyCode.UpArrow))
            jumpPressed = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * BULLET_SPEED;

        }
    }


    private void FixedUpdate()
    {
        //actually move the user
        user.velocity = new Vector2(SPEED * movementHorizontal, user.velocity.y);

        if (movementHorizontal < 0 && isFacingRight || movementHorizontal > 0 && !isFacingRight)
            Flip();

        if (jumpPressed && isGrounded)
            Jump();
        else
            jumpPressed = false;
    }

    private void Flip()
    {
        //flips the user when moving from left to right
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        animator.SetBool("isJumping", true);
        user.velocity = new Vector2(user.velocity.x, 0);
        user.AddForce(new Vector2(0, jumpForce));
        //Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if GrouncCheck Object is colliding with the other
        //2D colliders that are in the Ground layer
        //if yes (isGrounded True) else (isGrounded false)

        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ForegroundGround")
            isGrounded = true;
        
        animator.SetBool("isJumping", false);

        //constraints the user
        //where I got information for constraints:
        //https://answers.unity.com/questions/994941/how-do-i-stop-the-player-from-moving-offscreen.html
        if (collision.gameObject.tag == "wallLeft" || collision.gameObject.tag == "wallRight")
        {
            transform.position = transform.position;
        }


        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(scene);
        }


    }

}
