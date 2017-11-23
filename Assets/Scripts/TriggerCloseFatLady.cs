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
            fatLady.GoAway();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
