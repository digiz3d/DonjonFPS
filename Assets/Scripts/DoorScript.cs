using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    public bool opened = false;
    public float speed = 1.0f;
    public GameObject pivotPoint;
    public float maxAngle = 90f;
    public float minAngle = 0f;

    private float actualAngle = 0f;
    private bool moving = false;

    void Update() {
        if (!moving) return;

        if (opened)
        {
            actualAngle += (maxAngle - minAngle) * Time.deltaTime * speed;
            if (actualAngle < maxAngle)
            {
                gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, (maxAngle - minAngle) * Time.deltaTime * speed);
            }
            else
            {
                moving = false;
            }
        }
        else
        {
            actualAngle -= (maxAngle-minAngle) * Time.deltaTime * speed;
            if (actualAngle > minAngle)
            {
                gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, (- maxAngle - minAngle) * Time.deltaTime * speed);
            }
            else
            {
                moving = false;
            }
        }
    }

    public void Open()
    {
        opened = true;
        moving = true;
    }

    public void Close()
    {
        opened = false;
        moving = true;
    }

    public void Toggle()
    {
        opened = !opened;
        moving = true;
    }
}
