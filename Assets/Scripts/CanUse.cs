using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanUse : MonoBehaviour {
    [Range(1f,5f)]
    public float ArmsLength = 2.5f;

    private Transform CamTransform;

    // Update is called once per frame
    void Update () {
        HandleUseKey();
    }

    private void Start()
    {
        CamTransform = gameObject.transform.GetChild(0);
    }
    void HandleUseKey()
    {
        if (Input.GetButtonDown("Use"))
        {
            RaycastHit hit;
            if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit, ArmsLength))
            {
                //Debug.Log(hit.collider.gameObject.name); // prints the name of the object we're aiming at
                GameObject target = hit.collider.gameObject;

                CollectibleObject collectible = target.GetComponent<CollectibleObject>();
                if (collectible != null)
                {
                    collectible.Collect(GetComponent<IsWizard>());
                }

                InteractiveObject interactive = target.GetComponent<InteractiveObject>();
                if (interactive != null)
                {
                    interactive.Interact();
                }
            }
            Debug.DrawRay(CamTransform.position, CamTransform.forward * ArmsLength, Color.green, 5.0f);
        }
    }
}
