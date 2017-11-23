using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3.0f);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
