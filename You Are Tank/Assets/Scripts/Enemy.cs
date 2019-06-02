﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public List<Item> drops;

    private ItemSpawner itemSpawner;
    private Rigidbody2D rb;
    private Transform player;
    private float rotationVelocity;
    private float moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        itemSpawner = FindObjectOfType<ItemSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x,
                                        player.position.y - transform.position.y);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 5 && distance < 20)
        {
            transform.up = direction;
            rb.AddRelativeForce(Vector2.up * speed);
        }

    }

    void Die()
    {
        foreach (Item item in drops)
        {
            itemSpawner.Spawn(item, transform.position);
        }
    }

}
