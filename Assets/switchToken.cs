using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchToken : MonoBehaviour
{

    public GameObject ball;
    public GameObject hamster;

    public Transform activeTokenFollow;

    //public bool playerTokensTouching;

    // Start is called before the first frame update
    void Start()
    {
        hamster.SetActive(true);
        activeTokenFollow = hamster.transform;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (hamster.activeSelf == true && ball.GetComponent<platformerBall>().playerTokensTouching == true)
            {
                ball.GetComponent<platformerBall>().driven = true;


                //ball.SetActive(true);
                hamster.SetActive(false);

                ball.transform.position = this.transform.position;

                activeTokenFollow = ball.transform;
            }
            else
            {
                //ball.SetActive(false);
                hamster.SetActive(true);

                ball.GetComponent<platformerBall>().driven = false;

                hamster.transform.position = this.transform.position;

                activeTokenFollow = hamster.transform;

                
            }
        }

        this.transform.position = new Vector3(activeTokenFollow.position.x, activeTokenFollow.position.y, this.transform.position.z);




    }
}
