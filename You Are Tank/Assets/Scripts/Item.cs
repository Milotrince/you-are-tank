using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item")]
public class Item : ScriptableObject
{
    public int scraps;
    public int iron;
    public int ammo;
    public int fuel;
    public Sprite sprite;
}
