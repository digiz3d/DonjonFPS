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
        float forwardVelocity = Input.GetAxis("Vertical") * MovementSpeed;
        float strafeVelocity = Input.GetAxis("Horizontal") * MovementSpeed;

        if (!characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else if ( characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = JumpSpeed;
        }
        else
        {
            verticalVelocity = 0;
        }

        Vector3 movement = new Vector3(strafeVelocity, verticalVelocity, forwardVelocity);
        movement = transform.rotation * movement;
        characterController.Move(movement * Time.deltaTime);
    }
}
