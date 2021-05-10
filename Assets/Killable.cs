using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Killable : MonoBehaviour
{
    public UnityAction onDie;

    public void kill()
    {
        onDie.Invoke();
    }
}
