using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
