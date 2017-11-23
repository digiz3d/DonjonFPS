using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDayNightCycle : MonoBehaviour {

    public float timeMultiplier;

    protected Transform tr;
    protected Vector3 sr;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        sr = new Vector3();
    }
	
	// Update is called once per frame
	void Update () {
        sr.x = Time.deltaTime * timeMultiplier;

        tr.localEulerAngles += sr;
    }
}
