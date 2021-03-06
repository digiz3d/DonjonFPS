﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour {
    public float Sensitivity = 1.0f;

    private Transform CamTransform;

    private float XClamp;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        CamTransform = gameObject.transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {
        float y = Input.GetAxisRaw("Mouse X") * Sensitivity;
        float x = Input.GetAxisRaw("Mouse Y") * Sensitivity;
        //Debug.Log(x + " " +y);

        // rotate horizontally
        transform.localEulerAngles += new Vector3(0, y, 0);
        //Debug.Log(camTransform.eulerAngles);

        // rotate vertically
        XClamp -= x;
        XClamp = Mathf.Clamp(XClamp, -80.0f, 80.0f);

        //camTransform.localEulerAngles = new Vector3(XClamp, 0, 0);
        // =
        CamTransform.localRotation = Quaternion.Euler(XClamp, 0, 0);
    }
}
