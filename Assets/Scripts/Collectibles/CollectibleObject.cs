using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {
    public CanLaunchSpells wizard;

    public void Collect(GameObject whoCollectedMe)
    {
        if (gameObject.tag == "MagicWand")
        {
            wizard.GotMagicWand();
        }
        Debug.Log("Collected " + gameObject.name);
        Destroy(gameObject);
    }
}
