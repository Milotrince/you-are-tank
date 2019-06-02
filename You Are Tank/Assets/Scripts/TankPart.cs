using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankPart : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
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
            //healthText.text = _health.ToString();
            healthSlider.value = (float) _health / maxHealth;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    public int speed;
    public int mass;
    public Vector2Int coordinate;
    protected PlayerController player;
    public TankEntity tankEntity;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        _health = maxHealth;
        healthBarSpawner = FindObjectOfType<HealthBarSpawner>();
        healthBarSpawner.Spawn(this);
    }

    private void OnMouseDrag()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Item") || gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 1);
            transform.SetParent(player.transform);
            if (Mathf.Abs(transform.localPosition.x) <= 7 &&
                Mathf.Abs(transform.localPosition.y) <= 7)
            {
                transform.localRotation = Quaternion.identity;
                transform.localPosition = new Vector3(
                    Mathf.Round(transform.localPosition.x),
                    Mathf.Round(transform.localPosition.y),
                    0
                );
            }
            else
            {
                transform.SetParent(null);
            }
        }
    }

    private void OnMouseUp()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Item") || gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (transform.parent == player.transform)
            {
                bool added = player.tankEntity.AddPartXY(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.y), this);

                if (!added)
                {
                    transform.SetParent(null);
                }

            }
        }
    }

    void Die()
    {
        if (tankEntity != null && this == tankEntity.heart)
        {
            Enemy enemy = tankEntity.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
            }
            else if (tankEntity.gameObject.GetComponent<PlayerController>() != null)
            {
                player.Die();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
