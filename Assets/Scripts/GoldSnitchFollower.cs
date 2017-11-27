using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSnitchFollower : MonoBehaviour {
    public float Speed = 5f; // m/s
    public GameObject Player;

    private int nextIndex = 0;
    private List<Transform> path = new List<Transform>();
    private Vector3 direction;
    private Light childLight;

    private float startIntensity;
    private float finishIntensity = 6f;

    private float startRange;
    private float finishRange = 100f;

    private Color startColor;
    private Color finishColor = new Color(255f, 255f, 255f);

    private float timeToBright = 5f;
    private float timeSinceStart = 0f;

    private IEnumerator coroutine;

    // Use this for initialization
    void Start () {
        path.Add(gameObject.transform); // initial position
        path.Add(Player.transform);
        childLight = gameObject.transform.GetChild(0).GetComponent<Light>();

        startIntensity = childLight.intensity;
        startRange = childLight.range;
        startColor = childLight.color;
    }   

    // Update is called once per frame
    void Update()
    {
        direction = path[nextIndex].position - gameObject.transform.position;
        if (path[nextIndex].gameObject.tag == "Player")
        {
            direction += new Vector3(0f, 2.0f, 0f); // so we are above the player's head
        }
        if (direction.magnitude < 0.5f)
        {
            if (nextIndex + 2 <= path.Count)
            {
                nextIndex++;
            }
            else
            {
                Speed = 0f;
                Player.GetComponent<PlayerMoveScript>().enabled = false;
                if (timeSinceStart < timeToBright)
                {
                    timeSinceStart += Time.deltaTime;
                    childLight.intensity = Mathf.Lerp(startIntensity, finishIntensity, timeSinceStart / timeToBright);
                    childLight.range = Mathf.Lerp(startRange, finishRange, timeSinceStart / timeToBright);
                    childLight.color = Color.Lerp(startColor, finishColor, timeSinceStart / timeToBright);
                }
                else
                {
                    Application.Quit(); // dat ending XD
                }
            }
        }
        gameObject.transform.position += Vector3.Normalize(direction) * Speed * Time.deltaTime; // it moves at the exact speed
    }
}
