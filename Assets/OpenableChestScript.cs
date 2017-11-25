using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableChestScript : MonoBehaviour {
    public bool Looted = false;
    public GameObject[] Loots;

    private float OpeningSpeed = 4.0f;
    private float openAngle = -60f;
    private float closedAngle = 0f;
    private Transform lidTransform;
    private Transform pivotTransform;
    private Transform lootSpawnTransform;
    private float actualAngle = 0f;
    private Stack<GameObject> lootPool;

	// Use this for initialization
	void Start () {
        lidTransform = gameObject.transform.GetChild(0).transform;
        pivotTransform = gameObject.transform.GetChild(2).transform;
        lootSpawnTransform = gameObject.transform.GetChild(3).transform;
        lootPool = new Stack<GameObject>();
        foreach(GameObject loot in Loots)
        {
            GameObject o = Instantiate(loot, lootSpawnTransform);
            o.SetActive(false);
            lootPool.Push(o);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Looted)
        {
            actualAngle += (openAngle - closedAngle) * Time.deltaTime * OpeningSpeed;
            if (actualAngle > openAngle)
            {
                lidTransform.RotateAround(pivotTransform.position, gameObject.transform.right, (openAngle - closedAngle) * Time.deltaTime * OpeningSpeed);
            }
            else
            {
                foreach(GameObject loot in lootPool)
                {
                    loot.SetActive(true);
                    loot.transform.position = lootSpawnTransform.position;
                }
                Debug.Log("finiiii");
                Destroy(this);
            }
        }
	}

    public void Open()
    {
        Debug.Log("ah");
        if (!Looted)
        {
            Looted = true;
            Debug.Log("ouvert le coffre :)");
        }
    }
}
