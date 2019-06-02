using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [Range(1, 100)] public int damage;
    [Range(1.0f, 100.0f)] public float speed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb.AddRelativeForce(Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.health -= damage;
        }

        Destroy(gameObject);
    }

}
