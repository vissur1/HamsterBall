using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    protected Vector3 source;
    public Transform destination;

    protected float progress;
    public float time;

    public bool moveOnlyOnContact = false;
    protected bool contactMade = false;

    protected float direction = 1f;

    protected Collider2D col;

    protected LineRenderer line;

    // Start is called before the first frame update
    protected void Start()
    {
        source = transform.position;
        col = GetComponent<Collider2D>();

        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.endColor = Color.grey;
        line.startColor = Color.grey;
        line.endWidth = 0.05f;
        line.startWidth = 0.05f;
        line.sortingOrder = -1;
        Vector3[] points = new Vector3[2];
        points[0] = source;
        points[1] = destination.position;
        line.SetPositions(points);
    }

    protected void FixedUpdate()
    {
        if(contactMade || !moveOnlyOnContact)
        {
            progress += Time.deltaTime * direction;
        }
        Vector3 target = Vector3.Lerp(source, destination.position, progress / time);
        Vector3 difference = target - transform.position;
        transform.position = target;
        updateMoveables(difference);

        if (progress / time >= 1f)
        {
            direction = -1f;
        }
        if (progress / time <= 0f)
        {
            direction = 1f;
        }
    }

    protected void updateMoveables(Vector3 amount)
    {

        foreach (var obj in MoveableObject.moveables)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();

            if(collider != null && col.IsTouching(collider))
            {
                // only move the object if the object is above the platform
                if(collider.bounds.center.y > col.bounds.center.y)
                {
                    contactMade = true;
                    obj.transform.position += amount;
                }
            }
        }
    }

    protected void OnDrawGizmos()
    {
        if(destination != null)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawLine(transform.position, destination.position);
        }
    }
}
