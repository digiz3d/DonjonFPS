using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatLadyNPC : MonoBehaviour {
    public CanLaunchSpells wizard;

    private bool gone = false;

    public void TalkTo()
    {
        if (gone) return;

        if (!wizard.hasMagicWand)
        {
            Debug.Log("Va chercher ta baguette fdp");
        }
        else
        {
            Debug.Log("Pas mal gamin");
            GetComponent<DoorScript>().Open();
        }
        
    }

    public void GoAway()
    {
        this.gone = true;
    }
}
