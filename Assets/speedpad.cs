using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedpad : MonoBehaviour
{

    public float speedboost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        float boost = collider.GetComponent<Rigidbody2D>().velocity.x;

        boost = boost + speedboost;

        collider.GetComponent<Rigidbody2D>().velocity.x = boost;
    }*/

}
