using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestSpiderScript : MonoBehaviour {
    public float timer = 10f;
    public Transform Destination;

    public int Pv = 100;
	// Use this for initialization
	void Start () {
        GetComponent<NavMeshAgent>().destination = Destination.position;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            //Damage(10);
        }
        GetComponent<NavMeshAgent>().destination = Destination.position;
    }

    public void Damage(int d)
    {
        Pv -= d;
        GetComponent<Animator>().SetInteger("Pv", Pv);
        if (Pv <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
