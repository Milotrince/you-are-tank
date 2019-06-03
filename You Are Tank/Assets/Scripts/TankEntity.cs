using UnityEngine;

public class TankEntity : MonoBehaviour
{

    public TankPart heart;
    public int speed;
    public TankPart[,] parts;
    private Rigidbody2D rb;


    public void Initialize()
    {
        parts = new TankPart[15, 15];
        rb = GetComponent<Rigidbody2D>();
        parts[7, 7] = heart;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            TankPart tankPart = child.gameObject.GetComponent<TankPart>();
            if (tankPart != null)
            {
                AddPartXY((int) child.localPosition.x, (int) child.localPosition.y, tankPart);
            }
        }
    }

    public TankPart GetPartXY(int x, int y)
    {
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
                 x <= parts.GetLength(0) / 2 && x > -parts.GetLength(0) / 2 &&
                 y <= parts.GetLength(0) / 2 && y > -parts.GetLength(1) / 2
                 && (GetPartXY(x + 1, y) != null || GetPartXY(x - 1, y) != null ||
                 GetPartXY(x, y + 1) != null || GetPartXY(x, y - 1) != null)
                 )
        {
            parts[x + parts.GetLength(0) / 2, y + parts.GetLength(1) / 2] = p;

            p.gameObject.transform.SetParent(transform);
            p.gameObject.layer = gameObject.layer;
            for (int i = 0; i < p.transform.childCount; i++)
            {
                Transform child = p.transform.GetChild(i);
                child.gameObject.layer = gameObject.layer;
            }
            p.tankEntity = this;
            return true;
        }
        return false;
    }

    public bool RemovePart(TankPart p)
    {
        if (p == heart)
        {
            Debug.Log("Cannot remove heart part");
            return false;
        }

        TankPart actualPart = GetPartXY(p.coordinate.x, p.coordinate.y);
        if (actualPart == p)
        {
            parts[p.coordinate.x + 7, p.coordinate.y + 7] = null;
            p.transform.SetParent(null);

            p.gameObject.layer = LayerMask.NameToLayer("Item");
            return true;
        }

        return false;
    }

}
