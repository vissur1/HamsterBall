using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    public Transform Object1;
    public Transform Object2;

    public bool visable;

    public GameObject textElement;

    public TextMesh text;

    public Color invis;
    public Color vis;


    void Start()
    {

         text = GetComponent<TextMesh>();

         invis = new Color32(255, 128, 0, 0);

        vis = new Color32(0, 0, 0, 255);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) > 6)
        {
            //     print("tada");


            // text.color = invis;


            //text.color = new Color32(255, 128, 0, 255);

            text.color = invis;
          //  print(text.color);

        }

        else
        {

          // print("tada");
            text.color = vis;
           // print(text.color);


        }
    }
}
