using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;


    public void Spawn(Item item, Vector3 location)
    {
        GameObject newItemObject= Instantiate(itemPrefab, transform);

        newItemObject.transform.position = location +new Vector3(Random.Range(0f, 2f), Random.Range(0f, 2f), 0);
        ItemController newItem = newItemObject.GetComponent<ItemController>();
        newItem.item = item;

        SpriteRenderer spriteRenderer = newItem.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }
}
