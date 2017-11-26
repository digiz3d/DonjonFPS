using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {
    public void Interact()
    {
        FatLadyNPC fatlady = gameObject.GetComponent<FatLadyNPC>();
        if (fatlady != null)
        {
            fatlady.TalkTo();
            return;
        }

        DoorScript door = gameObject.GetComponent<DoorScript>();
        if (door != null)
        {
            door.Toggle();
            return;
        }

        OpenableChestScript chest = gameObject.GetComponent<OpenableChestScript>();
        if (chest != null)
        {
            chest.Open();
            return;
        }

        InterruptScript interrupt = gameObject.GetComponent<InterruptScript>();
        if (interrupt != null)
        {
            interrupt.Toggle();
        }

        InterruptEnd interruptEnd = gameObject.GetComponent<InterruptEnd>();
        if (interruptEnd != null)
        {
            interruptEnd.Down();
        }
    }
}
