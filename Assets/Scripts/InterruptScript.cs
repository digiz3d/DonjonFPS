using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptScript : MonoBehaviour {
    public bool IsUp;
    public OpeningByLeversScript OpeningByLever;

    private bool wasUp; // so we can change isUp in Unity editor and see the interrup move.
    private Transform pivotTransform;
    private Transform leverTransform;
    private float OpeningSpeed = 1f;
    private float upAngle = -40f;
    private float downAngle = 40f;
    private float actualAngle;
    private bool manuallyStarted = false;

    // Use this for initialization
    void Start () {
        pivotTransform = gameObject.transform.GetChild(0).transform;
        leverTransform = gameObject.transform.GetChild(1).transform;
        wasUp = !IsUp;
        actualAngle = (IsUp) ? upAngle : downAngle;
        leverTransform.RotateAround(pivotTransform.position, gameObject.transform.right, actualAngle);
    }
	
	// Update is called once per frame
	void Update () {
        float currentFrameAddedAngle;
        if (IsUp != wasUp)
        {
            
            if (IsUp)
            {
                currentFrameAddedAngle = upAngle * Time.deltaTime * OpeningSpeed;
                actualAngle += currentFrameAddedAngle;
                if (actualAngle > upAngle)
                {
                    leverTransform.RotateAround(pivotTransform.position, gameObject.transform.right, currentFrameAddedAngle);
                }
                else
                {
                    FinishedMoving(true);
                }
            }
            else
            {
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
	}

    public void Toggle()
    {
        wasUp = IsUp;
        IsUp = !IsUp;
        manuallyStarted = true;
    }

    void FinishedMoving(bool nowUp)
    {
        wasUp = nowUp;
        IsUp = nowUp;
        if (manuallyStarted)
        {
            if (OpeningByLever != null)
            {
                OpeningByLever.TriggerActivated();
            }
        }
    }
}
