using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseFatLady : MonoBehaviour {
    public DoorScript door;
    public FatLadyNPC fatLady;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Close();
            fatLady.GoToSleep();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
}
