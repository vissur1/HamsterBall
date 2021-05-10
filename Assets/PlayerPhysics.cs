using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPhysics : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D col;

    public float speed;
    public float jumpSpeed;

    public LayerMask ground;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        Killable killable = GetComponent<Killable>();
        killable.onDie += onDie;
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
        if(Input.GetButtonDown("Jump") && col.IsTouchingLayers(ground))
        {
            moveY = jumpSpeed;
        }

        DoMove(new Vector2(moveX, moveY));
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
}
