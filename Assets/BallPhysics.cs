using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class BallPhysics : PlayerPhysics
{
    /*public bool driven = false;

    protected override void Update()
    {
        if (driven)
        {
            base.Update();
        }
    }

    protected override void DoMove(Vector2 movement)
    {
        rb.AddForce(movement * Vector2.right);
        rb.velocity = movement * Vector2.up;
    }*/



/*void OnCollisionStay2D(Collision2D collision)  //CHANGE THIS. At the moment, player can fly by spamming space while in the air due to how this only changes on impact registry
{
    if (collision.gameObject.tag == "player")
    {
        playerTokensTouching = true;
    }
    else
    {
        playerTokensTouching = false;
    }

}*/




//}*/


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

    /*protected virtual void onDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

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


           // print("ye");

            float moveX = rb.velocity.x;
            float moveY = rb.velocity.y;


            moveX = moveX * boostSpeed;

            moveY = moveY * boostSpeed;

            DoMove(new Vector2(moveX, moveY));
        }
    }

}