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
            player.Scraps += item.scraps;
            player.Iron += item.iron;
            player.Ammo += item.ammo;
            player.Fuel += item.fuel;

            Destroy(gameObject);
        }
    }
}
