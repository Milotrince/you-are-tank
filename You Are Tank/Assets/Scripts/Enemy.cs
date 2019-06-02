using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public TMP_Text healthText;
    public Slider healthSlider;
    public int totalHealth;
    private HealthBarSpawner healthBarSpawner;

    private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthText.text = _health.ToString();
            healthSlider.value = _health / totalHealth;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

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
        healthBarSpawner = FindObjectOfType<HealthBarSpawner>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        itemSpawner = FindObjectOfType<ItemSpawner>();
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        StartCoroutine(Fire());

        GameObject healthBarObject = Instantiate(healthBarSpawner.healthBarPrefab, healthBarSpawner.transform);
        healthText = healthBarObject.GetComponentInChildren<TMP_Text>();
        healthSlider = healthBarObject.GetComponentInChildren<Slider>();
        UIFollowObject followScript = healthBarObject.GetComponent<UIFollowObject>();
        followScript.target = transform;
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
                newProjectileObject.layer = LayerMask.NameToLayer("EnemyProjectile");
                Projectile newProjectile = newProjectileObject.GetComponent<Projectile>();
                newProjectile.Initialize(transform);
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

        Destroy(gameObject);
    }

}
