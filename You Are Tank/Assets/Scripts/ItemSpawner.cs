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
        GameObject newItemObject= Instantiate(itemPrefab, transform);
        newItemObject.transform.position = location;
        ItemController newItem = newItemObject.GetComponent<ItemController>();
        newItem.item = item;

        SpriteRenderer spriteRenderer = newItem.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
        
    }
}
