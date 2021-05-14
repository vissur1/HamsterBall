using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTouch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Killable killable = collider.GetComponent<Killable>();
        if(killable != null)
        {
            killable.kill();
        }
    }
}
