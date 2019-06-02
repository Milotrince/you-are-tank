using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TankPart heart;
    public int speed;
    public int totalHealth;
    public TankPart[,] parts;

    private Rigidbody2D rb;
    private float rotationVelocity;
    private float moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        parts = new TankPart[15, 15];
        rb = GetComponent<Rigidbody2D>();
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
        rotationVelocity = Input.GetAxis("Horizontal") * speed;
        moveVelocity = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector2(Mathf.Cos(rb.rotation) * moveVelocity, Mathf.Sin(rb.rotation) * moveVelocity));
        rb.AddRelativeForce(Vector2.up * moveVelocity);
        rb.angularVelocity += rotationVelocity;
    }

    public TankPart GetPartXY(int x, int y)
    {
        return parts[x - (parts.GetLength(0)), y-(parts.GetLength(1)/2)];
    }
}
