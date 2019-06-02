using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public TankEntity tankEntity;
    public bool isHolding;

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
        tankEntity.Initialize();
        isHolding = false;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PlayerProjectile"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("EnemyProjectile"));

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationVelocity = -Input.GetAxis("Horizontal") * tankEntity.speed;
        moveVelocity = Input.GetAxis("Vertical") * tankEntity.speed;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * moveVelocity);
        rb.angularVelocity += rotationVelocity;
    }


    public void Die()
    {
        Debug.Log("You die");
        Destroy(gameObject);
    }

}
