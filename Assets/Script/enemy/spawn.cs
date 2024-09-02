using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public int counter;
    public GameObject[] enemies;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0,1f);
    }

    public void SpawnEnemy()
    {
        if (--counter == 0) CancelInvoke("SpawnEnemy");
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(4, 65),5, Random.Range(27, 89)), Quaternion.identity);
    }
}
