using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {
    private void OnCollisionEnter(Collision c)
    {
        Debug.Log("AAAAAAAH");
        if (c.gameObject.tag == "Sphere")
        {
            c.gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
        
    }
}
