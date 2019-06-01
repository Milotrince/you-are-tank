using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TankPart heart;
    public int speed;
    public List<List<TankPart>> parts;

    private Rigidbody2D rb;
    private float rotationVelocity;
    private float moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
