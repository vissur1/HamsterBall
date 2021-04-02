using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerHamster : MonoBehaviour
{
    Rigidbody2D rb;
    //Collider rb;

    public float speed;
    public float jumpSpeed;

    public float currentJumpSpeed;

    public float accelerateSpeed;

    public float jumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentJumpSpeed = jumpSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //updateJumping();
        float moveY = JumpCheck();
        //ContinueJump();

        float moveX = Move();

        rb.velocity = new Vector2(moveX, moveY);

    }

    

    float Move()
    {
        float a = Input.GetAxisRaw("Horizontal");
        //print(a);
        float moveBy = a * speed;

        return moveBy;
        //rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }




    float JumpCheck()
    {

        float a = Input.GetAxisRaw("Vertical");
        float moveBy = a * (currentJumpSpeed - accelerateSpeed);
        if (currentJumpSpeed > 0 && a > 0)
        {
            currentJumpSpeed = currentJumpSpeed - 1;
        }
        if (accelerateSpeed > 0 && a > 0)
        {
            accelerateSpeed = accelerateSpeed - 2;
        }
        if (a < 0)
        {
            moveBy = -jumpSpeed/2;
        }

        return moveBy;


    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject.tag);
        currentJumpSpeed = jumpSpeed;
        accelerateSpeed = jumpSpeed;
    }

    /*void OnCollisionStay2D(Collision2D collision) //causes massive lag
    {
        currentJumpSpeed = jumpSpeed;
        accelerateSpeed = jumpSpeed;
    }*/


}
