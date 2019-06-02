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

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, 1);
        transform.SetParent(controller.transform);
        if (Mathf.Abs(transform.localPosition.x) <= 7 &&
            Mathf.Abs(transform.localPosition.y) <= 7) {
            transform.localRotation = Quaternion.identity;
            transform.localPosition = new Vector3(
                                            Mathf.Round(transform.localPosition.x),
                                            Mathf.Round(transform.localPosition.y),
                                            0);
        }
        else
        {
            transform.SetParent(null);
        }
    }

    private void OnMouseUp()
    {
        if (transform.parent == controller.transform)
        {
            bool added = controller.AddPartXY(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.y), this);
            
            if (!added)
            {
                transform.SetParent(null);
            }
            
        }
    }
    // Update is called once per frame
    protected void Update()
    {
    }
}
