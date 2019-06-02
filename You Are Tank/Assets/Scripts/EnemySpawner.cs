using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }


    IEnumerator Spawner()
    {
        while (true)
        {
            GameObject enemyObject = Instantiate(enemyPrefab);

            yield return new WaitForSeconds(5);
        }
    }
}
