using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumosSpellProjectile : MonoBehaviour {
    public float Speed = 7f;
    private bool moving = true;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 20.0f);
    }

    void FixedUpdate()
    {
        if (moving)
        {
            transform.Translate(transform.forward * Time.deltaTime * Speed, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MagicProjectile")
        {
            return;
        }

        moving = false;
    }
}
