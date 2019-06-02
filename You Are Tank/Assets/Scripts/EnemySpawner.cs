using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        playerTransform = player.transform;
        StartCoroutine(Spawner());
    }


    IEnumerator Spawner()
    {
        while (true)
        {
            float distance = Vector3.Distance(playerTransform.position, transform.position);
            if (distance < 30 && distance > 20)
            {
                GameObject enemyObject = Instantiate(enemyPrefab);
                enemyObject.transform.position = transform.position;
            }

            yield return new WaitForSeconds(5);
        }
    }
}
