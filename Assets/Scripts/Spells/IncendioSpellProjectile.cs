using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncendioSpellProjectile : MonoBehaviour {
    public float Speed = 20f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3.0f);
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * Time.deltaTime * Speed, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MagicProjectile")
        {
            return;
        }

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
