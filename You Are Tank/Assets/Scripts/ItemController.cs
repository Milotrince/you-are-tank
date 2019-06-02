using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    Item item;

    public void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.scraps += item.scraps;
            player.iron += item.iron;
            player.ammo += item.ammo;
            player.fuel += item.fuel;

            Destroy(gameObject);
        }
    }
}
