using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour {

    public float speed;
    public Color[] Colors;

	void Update () {
        //Debug.Log("Je suis le update");
        float f = Time.deltaTime * speed;
        GetComponent<Transform>().localScale += new Vector3(f,f,f);
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.01f,1.0f,1.0f);

    }
}
