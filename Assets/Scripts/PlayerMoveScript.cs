using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public float MovementSpeed = 5.0f;
    public float JumpSpeed = 3.0f;


    private float verticalVelocity = 0.0f;
    CharacterController characterController;
    
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float forwardSpeed = Input.GetAxis("Vertical") * MovementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * MovementSpeed;

        if (!characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else if ( characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = JumpSpeed;
        }

        Vector3 movement = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        movement = transform.rotation * movement;
        characterController.Move(movement * Time.deltaTime);
    }
}
