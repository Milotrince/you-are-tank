using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;

    // Use this for initialization
    void Start()
    {

    }

    public void Spawn(Item item, Vector3 location)
    {
        GameObject newItem = Instantiate(itemPrefab, transform);
        newItem.transform.position = location;
        SpriteRenderer spriteRenderer = newItem.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
        
    }
}
