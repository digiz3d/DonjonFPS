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
            Destroy(this, 5.0f);
        }
    }

    private void OnDestroy()
    {
        subtitles.Display("<i>Il fait sombre... je devrais pouvoir arranger ça.</i>");
    }
}
