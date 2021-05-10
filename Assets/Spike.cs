using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spike : MonoBehaviour
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
