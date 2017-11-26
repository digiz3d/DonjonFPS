﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningByLeversScript : MonoBehaviour {

    public DialogSubtitles subtitles;
    public InterruptScript[] interrupts;

    public void TriggerActivated() {

        subtitles.Display("<i>*click*</i>");
        foreach (InterruptScript interrupt in interrupts)
        {
            // we want all the interupts down !
            if (interrupt.IsUp)
            {
                return;
            }
        }

        subtitles.Display("<i>*BRRPLRPLRPRPRRPLRPRRPLR* (bruit d'un mur qui bouge)</i>");
        gameObject.transform.localPosition += new Vector3(1.3f,0f,0f);
        //Destroy(gameObject, 1.0f);
    }
}
