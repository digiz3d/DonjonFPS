using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptEnd : MonoBehaviour
{
    public TowerLightScript[] towerLights;
    public GameObject GoldSnitch;

    private bool IsUp = true; // one-way interrupt up to down -> private
    private bool wasUp = true;
    private Transform pivotTransform;
    private Transform leverTransform;
    private float OpeningSpeed = 1f;
    private float upAngle = -40f;
    private float downAngle = 40f;
    private float actualAngle;

    // Use this for initialization
    void Start()
    {
        pivotTransform = gameObject.transform.GetChild(0).transform;
        leverTransform = gameObject.transform.GetChild(1).transform;
        actualAngle = (IsUp) ? upAngle : downAngle;
        leverTransform.RotateAround(pivotTransform.position, gameObject.transform.right, actualAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUp != wasUp)
        {
            float currentFrameAddedAngle;

            currentFrameAddedAngle = downAngle * Time.deltaTime * OpeningSpeed;
            actualAngle += currentFrameAddedAngle;
            if (actualAngle < downAngle)
            {
                leverTransform.RotateAround(pivotTransform.position, gameObject.transform.right, currentFrameAddedAngle);
            }
            else
            {
                FinishedMoving(false);
            }
        }
    }

    public void Down()
    {
        if (!IsUp) return;

        IsUp = false;
    }

    void FinishedMoving(bool nowUp)
    {
        Debug.Log("finished moving");
        IsUp = nowUp;
        wasUp = nowUp;
        StartCoroutine(TurnLightsOff());
    }

    IEnumerator TurnLightsOff()
    {
        foreach(TowerLightScript towerLight in towerLights)
        {
            Debug.Log("on a éteind la mumière " + towerLight.gameObject.name);
            towerLight.TurnOffInstant();
            yield return new WaitForSeconds(2.0f);
        }
        yield return new WaitForSeconds(2.0f);
        GoldSnitch.SetActive(true);
    }
}
