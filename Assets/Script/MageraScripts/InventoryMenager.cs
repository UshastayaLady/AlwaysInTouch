using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(GameObject gameObject, string nameObg)
    {
        InventoryItem newItem = new InventoryItem(gameObject, nameObg.Trim());
        items.Add(newItem);
    }

    public void DeleteItem (string nameObg)
    {        
        InventoryItem itemFind = items.Find(item => item.NameItem == nameObg.Trim());
        if (itemFind != null)
        {
            items.Remove(itemFind);
        }
        else
        {
            Debug.Log("Объект не найден");
        }
    }

    public bool FindItem(string nameObg)
    {
        InventoryItem itemFind = items.Find(item => item.NameItem == nameObg.Trim());
        if (itemFind != null)
        {
            return true;
        }
        else
        {
            Debug.Log("Объект не найден");
            return false;
        }
    }
}
