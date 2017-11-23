using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 1.0f;
    public float jumpSpeed = 3.0f;


    private float previousRotUpDown;
    private float verticalVelocity = 0;
    CharacterController characterController;
    
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        
    }
	
	// Update is called once per frame
	void Update () {
        

        // rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        float rotUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, rotLeftRight, 0);

        previousRotUpDown -= rotUpDown;
        previousRotUpDown = Mathf.Clamp(previousRotUpDown, -60.0f, 60.0f);
        Camera.main.transform.localRotation = Quaternion.Euler(previousRotUpDown, 0,0);
        

        // movements
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if ( characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }
        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }
}
