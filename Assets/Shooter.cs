using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public int interval = 60;
    public GameObject projectile;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        count++;
        if(count >= interval)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            count = 0;
        }
    }
}
