using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    public static List<MoveableObject> moveables = new List<MoveableObject>();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        MoveableObject.moveables.Add(this);
    }

    protected virtual void OnDestroy()
    {
        MoveableObject.moveables.Remove(this);
    }
}
