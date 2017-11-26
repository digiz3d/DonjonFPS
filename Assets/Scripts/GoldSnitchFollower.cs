using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSnitchFollower : MonoBehaviour {
    public Transform FollowingObject = null;
    public float speed = 1f;

    private Vector3 v;
	// Use this for initialization
	void Start () {
        v = new Vector3(FollowingObject.position.x, FollowingObject.position.y + 2.0f, FollowingObject.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (FollowingObject == null)
        {
            return;
        }
        v = new Vector3(FollowingObject.position.x, FollowingObject.position.y + 2.0f, FollowingObject.position.z);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.localPosition, v , Time.deltaTime * speed);
    }

    public void FollowObject(Transform transformToFollow)
    {
        FollowingObject = transformToFollow;
    }
}
