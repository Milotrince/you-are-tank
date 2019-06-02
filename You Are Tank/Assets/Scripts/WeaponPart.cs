using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponPart : TankPart
{

    public GameObject bulletPrefab;
    public Transform turret;

    private EventSystem eventSystem;

    void Start()
    {
        base.Start();
        eventSystem = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = new Vector2(mousePos.x - turret.position.x,
                                            mousePos.y - turret.position.y);
            turret.up = direction;

            if (Input.GetButtonDown("Fire1") && player.Ammo > 0 && eventSystem.currentSelectedGameObject == null)
            {
                player.Ammo--;
                Fire();
            }
        }
    }
    
    public void Fire()
    {
        GameObject newProjectileObject = Instantiate(bulletPrefab);
        Projectile newProjectile = newProjectileObject.GetComponent<Projectile>();
        int playerLayer = LayerMask.NameToLayer("Player");
        int layer = gameObject.layer == playerLayer ? LayerMask.NameToLayer("PlayerProjectile") : LayerMask.NameToLayer("EnemyProjectile");
        newProjectile.Initialize(turret.transform, layer);
    }
}
