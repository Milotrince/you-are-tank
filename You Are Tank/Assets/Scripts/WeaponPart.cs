using UnityEngine;
using System.Collections;

public class WeaponPart : TankPart
{

    public GameObject bulletPrefab;

    public Transform turret;

    // Use this for initialization
    void Start()
    {


    }

    protected void Update()
    {
        base.Update();
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - turret.position.x, 
                                        mousePos.y - turret.position.y);
        turret.up = direction;

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    
    public void Fire()
    {
        GameObject newProjectileObject = Instantiate(bulletPrefab);
        Projectile newProjectile = newProjectileObject.GetComponent<Projectile>();
        newProjectile.Initialize(turret.transform);
    }
}
