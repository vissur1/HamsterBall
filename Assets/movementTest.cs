using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float move = 0f;
    public float speed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}