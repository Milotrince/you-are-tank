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
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (player != null)
        {
            player.Health -= damage;
        }
        else if (enemy != null)
        {
            enemy.Health -= damage;
        }

        Destroy(gameObject);
    }

}
