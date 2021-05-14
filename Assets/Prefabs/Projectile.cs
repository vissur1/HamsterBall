using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2.5f;
    public LayerMask ground;

    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // move to the right relative to current rotation
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if layermask contains the gameObject's layer
        if((ground & (1 << other.gameObject.layer)) != 0)
        {
            // destroy on impact with a wall
            Destroy(gameObject);
        }
    }
}
