using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIgnitableObject : MonoBehaviour {

    public bool IsLit = false;

    private ParticleSystem.EmissionModule childEmission;
    private Light childLight;

    // Use this for initialization
    void Start () {
        childEmission = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().emission;
        childLight = gameObject.transform.GetChild(1).gameObject.GetComponent<Light>();

        if (this.IsLit)
        {
            SetOnFire();
        }
        else
        {
            Extinguish();
        }
	}

    public void SetOnFire()
    {
        IsLit = true;

        childEmission.enabled = true;
        childLight.enabled = true;
    }

    public void Extinguish()
    {
        IsLit = false;
        childEmission.enabled = false;
        childLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsLit) return;

        HasHealth hasHealth = other.gameObject.GetComponent<HasHealth>();
        if (hasHealth)
        {
            Extinguish();
            hasHealth.InflictDamages(20f);
        }
    }
}
