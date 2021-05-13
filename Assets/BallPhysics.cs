using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BallPhysics : PlayerPhysics
{
    public bool driven = false;
 
    public float friction = 0.98f;
    public float maxSpeed = 7f;
 
    protected override void Update()
    {
        if (driven)
        {
            base.Update();
        }
    }
 
    protected override void DoMove(Vector2 movement)
    {
        Vector2 velocity = rb.velocity;
        velocity.y = movement.y;
        velocity.x *= friction;
        if (Math.Abs(velocity.x) > maxSpeed)
        {
            velocity.x = Math.Sign(velocity.x) * maxSpeed;
        }
        rb.velocity = velocity;
    
        rb.AddForce(movement * Vector2.right);
    }
}

/*
public class BallPhysics : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D col;

    public float speed;
    public float jumpSpeed;

    public LayerMask ground;

    public bool driven = false;

    public float momentum = 0;

    public float boostSpeed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        //Killable killable = GetComponent<Killable>();
        //killable.onDie += onDie;
    }

    protected virtual void onDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float moveX = rb.velocity.x;
        float moveY = rb.velocity.y;

        if (driven == true)
        {
            if (Input.GetButtonDown("Jump") && col.IsTouchingLayers(ground))
            {
                moveY = jumpSpeed;
            }


            moveX = moveX + HorizontalMove() / 100;

        }

        //print(rb.velocity.x);

        DoMove(new Vector2(moveX, moveY));
    }

    protected virtual float HorizontalMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float moveBy = horizontal * speed;

        momentum = momentum + moveBy;

        return moveBy;
    }

    protected virtual void DoMove(Vector2 movement)
    {
        rb.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "booster")
        {
            float moveX = rb.velocity.x;
            float moveY = rb.velocity.y;

            moveX = moveX * boostSpeed;

            moveY = moveY * boostSpeed;

            DoMove(new Vector2(moveX, moveY));
        }
    }
}
*/