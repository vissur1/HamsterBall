using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchToken : MonoBehaviour
{

    public GameObject ball;
    public GameObject hamster;

    protected Collider2D ballCollider;
    protected Collider2D hamsterCollider;

    public Transform activeTokenFollow;

    public Sprite empty;
    public Sprite full;

    protected BallPhysics ballController;
    protected SpriteRenderer ballRenderer;

    // Start is called before the first frame update
    void Start()
    {
        hamsterCollider = hamster.GetComponent<Collider2D>();
        ballCollider = ball.GetComponent<Collider2D>();

        hamster.SetActive(true);
        activeTokenFollow = hamster.transform;

        ballController = ball.GetComponent<BallPhysics>();
        ballRenderer = ball.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Switch") == true)
        {
            if (Vector3.Distance(ball.transform.position, hamster.transform.position) < 1.5 && hamster.activeSelf == true) {
                ballController.driven = true;
                ballRenderer.sprite = full;

                //ball.SetActive(true);
                hamster.SetActive(false);

                ball.transform.position = this.transform.position;

                activeTokenFollow = ball.transform;
            }
            else
            {
                //ball.SetActive(false);
                hamster.SetActive(true);

                ballRenderer.sprite = empty;
                ballController.driven = false;

                hamster.transform.position = this.transform.position;

                activeTokenFollow = hamster.transform;
            }
        }

        this.transform.position = new Vector3(activeTokenFollow.position.x, activeTokenFollow.position.y, this.transform.position.z);
    }
}
