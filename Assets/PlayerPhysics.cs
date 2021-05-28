using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPhysics : MoveableObject
{
    [Serializable]
    public enum State
    {
        Rising,
        Falling,
        Stopped
    }

    protected State state;
    protected int jump = 0;

    protected Rigidbody2D rb;
    protected Collider2D col;

    public float speed;
    public float jumpSpeed;

    public int coyoteTime = 30;
    protected int coyoteTimeLeft;

    public LayerMask ground;

    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        Killable killable = GetComponent<Killable>();
        killable.onDie += onDie;

        base.Start();
    }

    protected virtual void onDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float moveX = HorizontalMove();

        float moveY = rb.velocity.y;
        if(col.IsTouchingLayers(ground) && state == State.Stopped)
        {
            coyoteTimeLeft = coyoteTime;
        } else if(coyoteTimeLeft > 0)
        {
            coyoteTimeLeft--;
        }

        // the player has a brief period of time where they can jump after walking off an edge
        if(Input.GetButtonDown("Jump") && coyoteTimeLeft > 0)
        {
            jump = 45;
            moveY = jumpSpeed;
            coyoteTimeLeft = 0;
        }
        if(jump > 0)
        {
            jump--;
        }
        if(jump > 0 && Input.GetButtonUp("Jump"))
        {
            moveY *= 0.5f;
        }

        DoMove(new Vector2(moveX, moveY));
        UpdateState();
    }

    protected virtual float HorizontalMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float moveBy = horizontal * speed;

        return moveBy;
    }

    protected virtual void DoMove(Vector2 movement)
    {
        rb.velocity = movement;
    }

    protected virtual void UpdateState()
    {
        if(rb.velocity.y > 0.001f)
        {
            state = State.Rising;
        } else if(rb.velocity.y < -0.001f)
        {
            state = State.Falling;
        } else
        {
            state = State.Stopped;
        }
    }
}
