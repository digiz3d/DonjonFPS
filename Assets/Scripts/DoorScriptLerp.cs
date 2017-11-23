using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptLerp : MonoBehaviour {

    public Vector3 StartPosition;
    public Vector3 EndPosition;
    
    public bool isOpen = false;

    private float timer = 0.0f;
    // Use this for initialization
    void Start() {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = true;
            timer = 0.0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = false;
            timer = 1.0f;
        }
    }
    // Update is called once per frame
    void Update() {
        if (isOpen)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        transform.localPosition = Vector3.Lerp(StartPosition, EndPosition, timer);
    }
}
