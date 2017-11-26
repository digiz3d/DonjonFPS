using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidEnemyScript : MonoBehaviour {

    private float LateralSpeed = 2f;
    private float minX = -5.5f;
    private float maxX = -1.0f;
    public float progress;

    private float positionX;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        progress = (Mathf.Sin(Time.time* LateralSpeed) +1)/2;
        Debug.Log("progress = " + progress + " Time.time =" + Time.time);
        gameObject.transform.localPosition = new Vector3(Mathf.Lerp(minX, maxX, progress), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
	}
}
