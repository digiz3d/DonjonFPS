using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entré");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Reste");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Sorti");
    }
}
