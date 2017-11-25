using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanUse : MonoBehaviour {

    public Transform CamTransform;
    [Range(1f,5f)]
    public float ArmsLength = 2.5f;
	// Update is called once per frame
	void Update () {
        HandleUseKey();
    }

    void HandleUseKey()
    {
        if (Input.GetButtonDown("Use"))
        {
            Ray ray = new Ray(CamTransform.position, CamTransform.forward);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, ArmsLength))
            {
                //Debug.Log(hitInfo.collider.gameObject.name); // prints the name of the object we're aiming at
                Vector3 hitPoint = hitInfo.point;
                GameObject target = hitInfo.collider.gameObject;

                CollectibleObject collectible = target.GetComponent<CollectibleObject>();
                if (collectible != null)
                {
                    collectible.Collect(gameObject);
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
