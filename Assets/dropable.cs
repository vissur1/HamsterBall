using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropable : MonoBehaviour
{

    Rigidbody2D rb;

    //public Collider2D trigger;

    //public string "trigger";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    void OnCollisionStay2D(Collision2D collision) {

        if (collision.gameObject.tag == "player")
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

        /*if (collision.collider == trigger)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }*/

        /*if (collision.gameObject.tag == trigger)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }*/

    }

}
