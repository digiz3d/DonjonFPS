using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIgnitableObject : MonoBehaviour {

    public bool isOnFire = false;

	// Use this for initialization
	void Start () {
		if (this.isOnFire)
        {
            this.SetOnFire();
        }
        else
        {
            this.Extinguish();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetOnFire()
    {
        this.isOnFire = true;
        ParticleSystem.EmissionModule emission = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().emission;
        
        emission.enabled = true;

        Light light = gameObject.transform.GetChild(1).gameObject.GetComponent<Light>();
        light.enabled = true;
    }

    public void Extinguish()
    {
        this.isOnFire = false;
        ParticleSystem.EmissionModule emission = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().emission;
        emission.enabled = false;

        Light light = gameObject.transform.GetChild(1).gameObject.GetComponent<Light>();
        light.enabled = false;
    }
}
