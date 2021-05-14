using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{

    public Transform followTransform;


    // Update is called once per frame
    void Update()
    {
        

        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y + 1.5f, this.transform.position.z);
        

    }
}

