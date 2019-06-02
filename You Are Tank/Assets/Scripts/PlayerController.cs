using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TankPart heart;
    public int speed;
    public int totalHealth;
    public TankPart[,] parts;
    public bool isHolding;


    public int scraps;
    public int iron;
    public int ammo;
    public int fuel;

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
            //Debug.Log("AddPart true");
            return true;
        }
        //Debug.Log("AddPart false");
        return false;
    }
}
