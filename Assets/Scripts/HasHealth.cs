using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour {

    public float health = 100.0f;
    public Vector3 respawn;

    public void InflictDamages(float damages)
    {
        health -= damages;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<DialogSubtitles>().Display("<i>Vous êtes mort. Bon tranquille, pas vraiment cette fois.</i>");
            Respawn();
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public  void SaveSafeLocation(Vector3 position)
    {
        if (gameObject.tag == "Player")
        {
            respawn = position;
        }
        Debug.Log("partie sauvegardée");
    }

    void Respawn()
    {
        health = 100;
        gameObject.transform.position = respawn;
    }
}
