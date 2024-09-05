
using UnityEngine;

public class InventoryItem
{
    public GameObject Item;
    public string NameItem;

    public InventoryItem(GameObject gameObject, string strName)
    {
        Item = gameObject;
        NameItem = strName;
    }
}
