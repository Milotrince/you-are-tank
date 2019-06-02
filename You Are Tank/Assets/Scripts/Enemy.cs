using System.Collections;
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
    public GameObject bulletPrefab;

    private IEnumerator fire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        itemSpawner = FindObjectOfType<ItemSpawner>();
        gameObject.layer = LayerMask.NameToLayer("Enemies");
        fire = Fire();
        StartCoroutine(fire);
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

    IEnumerator Fire() {
        while (true) 
        {
            if ( Vector3.Distance(transform.position, player.transform.position) < 20)
            {
                GameObject newProjectileObject = Instantiate(bulletPrefab);
                Projectile newProjectile = newProjectileObject.GetComponent<Projectile>();
                newProjectile.Initialize(transform);
                newProjectile.gameObject.layer = LayerMask.NameToLayer("EnemyProjectile");
            }
            yield return new WaitForSeconds(1);
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
