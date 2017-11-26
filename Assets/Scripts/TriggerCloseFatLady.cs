using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseFatLady : MonoBehaviour {
    public DoorScript door;
    public FatLadyNPC fatLady;
    public DialogSubtitles subtitles;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Close();
            fatLady.GoToSleep();
            subtitles.Display("<i>Il fait sombre... je devrais pouvoir arranger ça.</i>");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
}
