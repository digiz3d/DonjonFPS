using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSnitchFollower : MonoBehaviour {
    public float Speed = 5f; // m/s
    public Transform PlayerTransform;
    public Transform FinalSpawn;

    private int nextIndex = 0;
    private List<Transform> path = new List<Transform>();
    private Vector3 direction;
    
	// Use this for initialization
	void Start () {
        path.Add(gameObject.transform);
        path.Add(PlayerTransform);
        path.Add(FinalSpawn);
    }   

    // Update is called once per frame
    void Update()
    {
        Debug.Log("on va a l'index " + nextIndex);
        direction = path[nextIndex].position - gameObject.transform.position;
        if (path[nextIndex].gameObject.tag == "Player")
        {
            direction += new Vector3(0, 2.0f, 0);
        }
        if (direction.magnitude < 0.5f)
        {
            if (nextIndex + 2 <= path.Count)
            {
                nextIndex++;
            }
            else
            {
                FinalSpawn.gameObject.GetComponent<SpawnEnemyScript>().SpawnEnemy();
                Destroy(gameObject);
            }
        }
        gameObject.transform.position += Vector3.Normalize(direction) * Speed * Time.deltaTime; // it moves at the exact speed
        Debug.Log("on est à l'index " + nextIndex);
    }
}
