using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [Range(1, 100)] public int damage;
    public float speed;
    private Rigidbody2D rb;

    public void Initialize(Transform turret)
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), turret.GetComponentInParent<Collider2D>());

        transform.rotation = turret.rotation;
        transform.position = turret.position;

        rb.AddForce(transform.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.health -= damage;
        }

        Destroy(gameObject);
    }

}
