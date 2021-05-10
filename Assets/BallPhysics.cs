using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : PlayerPhysics
{
    public bool playerTokensTouching = true;
    public bool driven = false;

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
    }
}
