using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public TankEntity tankEntity;

    public List<Item> drops;

    private Transform player;
    private Rigidbody2D rb;
    private ItemSpawner itemSpawner;
    private List<WeaponPart> weaponParts;
    private float lastFired;

    // Start is called before the first frame update
    void Start()
    {
        lastFired = 0f;
        tankEntity.Initialize();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        itemSpawner = FindObjectOfType<ItemSpawner>();
        gameObject.layer = LayerMask.NameToLayer("Enemy");

        weaponParts = new List<WeaponPart>();
        foreach (TankPart part in tankEntity.parts)
        {
            if (part is WeaponPart)
            {
                weaponParts.Add((WeaponPart) part);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = new Vector2(player.position.x - transform.position.x,
                                            player.position.y - transform.position.y);
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 20)
            {
                transform.up = direction;
                if (distance > 5)
                {
                    rb.AddRelativeForce(Vector2.up * tankEntity.speed);
                }

                if (Time.timeSinceLevelLoad - lastFired > 1f)
                {
                    foreach (WeaponPart part in weaponParts)
                    {
                        part.Fire();
                    }
                    lastFired = Time.timeSinceLevelLoad;
                }
            }
        }
    }

    public void Die()
    {
        foreach (Item item in drops)
        {
            itemSpawner.Spawn(item, transform.position);
        }

        Destroy(gameObject);
    }

}
