using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {

    public void Collect(IsWizard whoCollectedMe)
    {
        if (gameObject.tag == "MagicWand")
        {
            whoCollectedMe.GotMagicWand();
        }
        if (gameObject.tag == "EveryFlavourBean")
        {
            whoCollectedMe.AddEveryFlavourBeans(1);
        }
        // TODO : Display that in the HUD
        // Debug.Log("Tu viens de ramasser : " + gameObject.name);
        Destroy(gameObject);
    }
}
