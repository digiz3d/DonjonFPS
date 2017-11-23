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
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (!moving) return;

        Debug.Log("1");
        if (opened)
        {
            Debug.Log("2");
            actualAngle += (maxAngle - minAngle) * Time.deltaTime * speed;
            if (actualAngle < maxAngle)
            {
                Debug.Log("3");
                gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, (maxAngle - minAngle) * Time.deltaTime * speed);
            }
            else
            {
                Debug.Log("4");
                moving = false;
            }
        }
        else
        {
            Debug.Log("2 bis");
            actualAngle -= (maxAngle-minAngle) * Time.deltaTime * speed;
            if (actualAngle > minAngle)
            {
                Debug.Log("3 bis");
                gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, (- maxAngle - minAngle) * Time.deltaTime * speed);
            }
            else
            {
                Debug.Log("4 bis");
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
