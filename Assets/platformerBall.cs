using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class platformerBall : MonoBehaviour
{
    Rigidbody2D rb;
    //Collider rb;

    public bool isBouncing = false;

    public float speed = 5f;
    Vector2 movement;
    public float jumpSpeed;

    public float currentJumpSpeed;

    public float accelerateSpeed;

    public float inertia;

    public float bounce;

    public float jumpTime = 0;

    public bool playerTokensTouching;

    public bool driven;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentJumpSpeed = jumpSpeed;

        Killable killable = GetComponent<Killable>();
        killable.onDie += onDie;
    }

    void onDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;

        if (driven == true)
        {
            moveY = JumpCheck(Input.GetAxisRaw("Vertical"));
            moveX = Move(Input.GetAxisRaw("Horizontal"));
        }

        else
        {
            moveY = JumpCheck(0);
            moveX = Move(0);

        }

        if (!isBouncing)
        {
            //movement = new Vector2(moveX, moveY);

            //rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

           // print(rb.position);

            rb.velocity = new Vector2(moveX, moveY);
        }

     

    }



    float Move(float a)
    {
        float moveBy = a * (speed) + inertia;

        if (a != 0 && inertia < speed * 3)
        {
            inertia = inertia + a * (speed / 100);
            //print("dd");
        }
        else
        {
            if (inertia > 0)
            {
                inertia = inertia - (speed / 200);
            }
            if (inertia < 0)
            {
                inertia = inertia + (speed / 200);
            }
        }

        return moveBy;
        //rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }




    float JumpCheck(float a)
    {

        float moveBy = a * (currentJumpSpeed - accelerateSpeed);
        if (currentJumpSpeed > 0 && a > 0)
        {
            currentJumpSpeed--;
        }
        if (accelerateSpeed > 0 && a > 0)
        {
            accelerateSpeed = accelerateSpeed - 2;
        }
        if (a < 0)
        {
            moveBy = -jumpSpeed / 2;
        }

        return moveBy;


    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject.tag);
        currentJumpSpeed = jumpSpeed;
        accelerateSpeed = jumpSpeed;

        /*if (rb != null)
        {
            float bounce = 6f; //amount of force to apply
            rb.AddForce(collision.contacts[0].normal * bounce);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
        }*/
    }

    /*void StopBounce()
    {
        isBouncing = false;
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

}