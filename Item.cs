using UnityEngine;
[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public Texture itemIcon;
}
