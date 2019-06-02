using System.Collections;
using UnityEngine;

public class ItemRespawner : MonoBehaviour
{
    public Item item;

    private ItemSpawner itemSpawner;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        itemSpawner = FindObjectOfType<ItemSpawner>();
        PlayerController player = FindObjectOfType<PlayerController>();
        playerTransform = player.transform;

        StartCoroutine(Respawner());
    }

    IEnumerator Respawner()
    {
        while (true)
        {
            float distance = Vector3.Distance(playerTransform.position, transform.position);
            if (distance < 30 && distance > 20)
            {
                itemSpawner.Spawn(item, transform.position);
            }

            yield return new WaitForSeconds(5);
        }
    }

}
