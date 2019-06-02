using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPart : MonoBehaviour
{
    public int health;
    public int speed;
    public int mass;
    public Vector2Int coordinate;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetMouseButton(0) && (Camera.main.ScreenToWorldPoint(transform.InverseTransformPoint(Input.mousePosition)).magnitude <= 50))
        {
            controller.isHolding = true;
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(transform.InverseTransformPoint(Input.mousePosition)), 1);
            if ((transform.TransformPoint(transform.position) - controller.transform.position).magnitude < 20)
            {
                transform.SetParent(controller.transform);
            }
            else
            {
                transform.SetParent(null);
            }
        }
        else
        {
            controller.isHolding = false;
        }
        bool validLocation = true;
        if (Input.GetMouseButtonUp(0) && !validLocation) {
            transform.SetParent(null);
        }
    }

}
