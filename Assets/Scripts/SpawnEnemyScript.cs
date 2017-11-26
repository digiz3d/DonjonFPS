using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour {

    public GameObject Enemy;

    public void SpawnEnemy()
    {
        Enemy.SetActive(true);
    }
}
