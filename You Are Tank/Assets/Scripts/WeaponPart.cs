using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponPart : TankPart
{

    public GameObject bulletPrefab;
    public Transform turret;

    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    void Start()
    {
        base.Start();
        raycaster = FindObjectOfType<GraphicRaycaster>();
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

            if (Input.GetButtonDown("Fire1") && player.Ammo > 0 && !HoveringUI())
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


    public bool HoveringUI()
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> rayCastResults = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, rayCastResults);

        return rayCastResults.Count > 0;
    }
}
