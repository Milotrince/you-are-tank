using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    public Item item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit item");
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
