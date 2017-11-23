using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour {
    public float sensitivity = 1.0f;
    public Transform camTransform;

    private float XClamp;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        float y = Input.GetAxisRaw("Mouse X") * sensitivity;
        float x = Input.GetAxisRaw("Mouse Y") * sensitivity;
        //Debug.Log(x + " " +y);

        transform.localEulerAngles += new Vector3(0, y, 0);
        //Debug.Log(camTransform.eulerAngles);

        
        XClamp -= x;
        XClamp = Mathf.Clamp(XClamp, -60.0f, 60.0f);
        
        //camTransform.localEulerAngles = new Vector3(XClamp, 0, 0);
        // =
        camTransform.localRotation = Quaternion.Euler(XClamp, 0, 0);
    }
}
