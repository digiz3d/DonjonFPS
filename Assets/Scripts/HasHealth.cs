using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour {

    public float health = 100.0f;

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
        Destroy(gameObject);
    }
}
