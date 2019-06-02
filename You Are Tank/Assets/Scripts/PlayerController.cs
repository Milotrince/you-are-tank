using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public TankPart heart;

    public int speed;
    public int totalHealth;
    public TankPart[,] parts;
    public bool isHolding;

    public TMP_Text healthText;
    public Slider healthSlider;

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
        }
    }

    private int _scraps;
    public int Scraps
    {
        get
        {
            return _scraps;
        }
        set
        {
            _scraps = value;
            scrapsText.text = _scraps.ToString();
        }
    }
    private int _iron;
    public int Iron
    {
        get
        {
            return _iron;
        }
        set
        {
            _iron = value;
            ironText.text = _iron.ToString();
        }
    }
    private int _ammo;
    public int Ammo
    {
        get
        {
            return _ammo;
        }
        set
        {
            _ammo = value;
            ammoText.text = _ammo.ToString();
        }
    }

    private int _fuel;
    public int Fuel
    {
        get
        {
            return _fuel;
        }
        set
        {
            _fuel = value;
            fuelText.text = _fuel.ToString();
        }
    }

    public TMP_Text scrapsText;
    public TMP_Text ironText;
    public TMP_Text ammoText;
    public TMP_Text fuelText;

    private Rigidbody2D rb;
    private float rotationVelocity;
    private float moveVelocity;


    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
        parts = new TankPart[15, 15];
        rb = GetComponent<Rigidbody2D>();
        parts[7, 7] = heart;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PlayerProjectile"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("EnemyProjectile"));
    }

    void UpdateTotalHealth()
    {
        totalHealth = 0;
        for (int x = 0; x < 15; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                totalHealth += parts[x, y].health;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotationVelocity = -Input.GetAxis("Horizontal") * speed;
        moveVelocity = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * moveVelocity);
        rb.angularVelocity += rotationVelocity;
    }

    public TankPart GetPartXY(int x, int y)
    {
        //error checking
        //Debug.Log("Trying to get " + x + " " + y);
        x += parts.GetLength(0) / 2;
        y += parts.GetLength(1) / 2;
        if (x < 0 || x >= parts.GetLength(0) || y < 0 || y > parts.GetLength(1))
        {
            return null;
        }
        return parts[x, y];
    }

    public bool AddPartXY(int x, int y, TankPart p)
    {
       if (GetPartXY(x, y) == null && 
                x <= parts.GetLength(0)/2 && x > -parts.GetLength(0)/2 && 
                y <= parts.GetLength(0)/2 && y > -parts.GetLength(1)/2 
                && (GetPartXY(x + 1, y) != null || GetPartXY(x - 1, y) != null || 
                GetPartXY(x, y + 1) != null || GetPartXY(x, y - 1) != null)
                )
        {
            parts[x + parts.GetLength(0)/2, y + parts.GetLength(1)/2] = p;
            p.gameObject.transform.SetParent(transform);
            p.gameObject.layer = LayerMask.NameToLayer("Player");
            //Debug.Log("AddPart true");
            return true;
        }
        //Debug.Log("AddPart false");
        return false;
    }
}
