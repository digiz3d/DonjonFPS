using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    public bool Opened = false;
    public float Speed = 1.0f;
    public GameObject PivotPoint;
    public float MaxAngle = 90f;
    public float MinAngle = 0f;

    private float actualAngle = 0f;
    private bool moving = false;

    void Update() {
        if (!moving)
        {
            return;
        }

        if (Opened)
        {
            actualAngle += (MaxAngle - MinAngle) * Time.deltaTime * Speed;
            if (actualAngle < MaxAngle)
            {
                gameObject.transform.RotateAround(PivotPoint.transform.position, Vector3.up, (MaxAngle - MinAngle) * Time.deltaTime * Speed);
            }
            else
            {
                moving = false;
            }
        }
        else
        {
            actualAngle -= (MaxAngle-MinAngle) * Time.deltaTime * Speed;
            if (actualAngle > MinAngle)
            {
                gameObject.transform.RotateAround(PivotPoint.transform.position, Vector3.up, (- MaxAngle - MinAngle) * Time.deltaTime * Speed);
            }
            else
            {
                moving = false;
            }
        }
    }

    public void Open()
    {
        Opened = true;
        moving = true;
    }

    public void Close()
    {
        Opened = false;
        moving = true;
    }

    public void Toggle()
    {
        Opened = !Opened;
        moving = true;
    }
}
