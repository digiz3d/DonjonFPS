using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIgnitableObject : MonoBehaviour {

    public bool IsLit = false;

    private ParticleSystem.EmissionModule childEmission;
    private Light childLight;

    // Use this for initialization
    void Start () {
        this.childEmission = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().emission;
        this.childLight = gameObject.transform.GetChild(1).gameObject.GetComponent<Light>();

        if (this.IsLit)
        {
            this.SetOnFire();
        }
        else
        {
            this.Extinguish();
        }
	}

    public void SetOnFire()
    {
        this.IsLit = true;

        childEmission.enabled = true;
        childLight.enabled = true;
    }

    public void Extinguish()
    {
        this.IsLit = false;
        childEmission.enabled = false;
        childLight.enabled = false;
    }
}
