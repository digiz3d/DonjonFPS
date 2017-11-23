using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {
    public IsWizard wizard;

    public void Collect(GameObject whoCollectedMe)
    {
        if (gameObject.tag == "MagicWand")
        {
            wizard.GotMagicWand();
        }
        Debug.Log("Tu viens de ramasser : " + gameObject.name);
        Destroy(gameObject);
    }
}
