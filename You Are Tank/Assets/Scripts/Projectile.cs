using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [Range(1, 100)] public int damage;
    public float speed;
    private Rigidbody2D rb;
    private Vector3 origin;

    public void Initialize(Transform turret, int layer)
    {
        gameObject.layer = layer;
        origin = turret.position;
        rb = GetComponent<Rigidbody2D>();

        transform.rotation = turret.rotation;
        transform.position = turret.position;

        rb.AddForce(transform.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D childCollider = collision.GetContact(0).collider;
        TankPart tankPart = childCollider.gameObject.GetComponent<TankPart>();
        if (tankPart != null)
        {
            tankPart.Health -= damage;
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, origin) > 100f)
        {
            Destroy(gameObject);
        }
    }

}
