using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {
    public float movementSpeed = 10.0f;
    public float jumpVelocity = 400.0f;
    public float maxSpeed = 5.0f;


    private bool CanJump = true;
	// Use this for initialization
	void Start () {
		
	}
    
    // Update is called once per frame
    void FixedUpdate () {
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)

        if (Input.GetKey(KeyCode.Z))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce( transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Rigidbody>().AddForce(-transform.right * movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpVelocity, 0));
            Debug.Log("saut!");
        }
        CanJump = false;
    }

    private void OnTriggerStay(Collider other)
    {
        CanJump = true;
    }
}
