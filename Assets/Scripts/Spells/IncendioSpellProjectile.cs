﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncendioSpellProjectile : MonoBehaviour {
    public float speed = 20f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        IsIgnitableObject isIgnitableObject = go.GetComponent<IsIgnitableObject>();
        if (isIgnitableObject != null)
        {
            isIgnitableObject.SetOnFire();
        }

        HasHealth hasHealt = go.GetComponent<HasHealth>();
        if (hasHealt != null)
        {
            hasHealt.InflictDamages(50.0f);
        }

        Destroy(gameObject);
    }
}