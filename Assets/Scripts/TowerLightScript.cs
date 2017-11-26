using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLightScript : MonoBehaviour {
    public bool IsOn;
    public AudioClip AudioOff;

    private AudioSource childSoundEmitter;
    private Material bulbMaterial;
    private Light lightObject;
    private float startIntensity = 0f;
    private float finishIntensity;

    private float startRange = 0f;
    private float finishRange;

    private Color startColor = new Color(0f, 0f, 0f);
    private Color finishColor;

    private float timeToBright = 0.5f;
    private float timeSinceStart = 0f;
	// Use this for initialization
	void Start () {
        childSoundEmitter = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        lightObject = gameObject.transform.GetChild(1).GetComponent<Light>();
        bulbMaterial = gameObject.transform.GetChild(2).GetComponent<Renderer>().material;

        finishIntensity = lightObject.intensity;
        finishRange = lightObject.range;
        finishColor = bulbMaterial.GetColor("_EmissionColor");

        lightObject.enabled = (IsOn) ? true : false;
        lightObject.intensity = (IsOn) ? finishIntensity : startIntensity;
        lightObject.range = (IsOn) ? finishRange : startRange;

        bulbMaterial.SetColor("_EmissionColor", (IsOn) ? finishColor : startColor);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (IsOn)
            {
                return;
            }
            lightObject.enabled = true;
            bulbMaterial.SetColor("_EmissionColor", new Color(255f, 255f, 0f, 0.5f));
            other.GetComponent<HasHealth>().SaveSafeLocation(other.transform.position);
            StartCoroutine("TurnOnLightSlowly");
        }
    }

    // my first coroutine lol it was just to try it :D
    IEnumerator TurnOnLightSlowly()
    {
        while (lightObject.intensity < finishIntensity)
        {
            timeSinceStart += Time.deltaTime;
            lightObject.intensity = Mathf.Lerp(startIntensity, finishIntensity, timeSinceStart / timeToBright);
            lightObject.range = Mathf.Lerp(startRange, finishRange, timeSinceStart / timeToBright);
            bulbMaterial.SetColor("_EmissionColor", Color.Lerp(startColor, finishColor, timeSinceStart / timeToBright));
            yield return null;
        }
        IsOn = true;
    }

    public void TurnOffInstant()
    {
        lightObject.intensity = startIntensity;
        lightObject.range = startRange;
        bulbMaterial.SetColor("_EmissionColor", startColor);
        childSoundEmitter.PlayOneShot(AudioOff);
    }
}
