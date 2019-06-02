using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TankPart heart;
    public int speed;
    public List<List<TankPart>> parts;

    private Rigidbody2D rb;
    private Transform player;
    private float rotationVelocity;
    private float moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        rb.AddRelativeForce(Vector2.up * speed);
    }

}
