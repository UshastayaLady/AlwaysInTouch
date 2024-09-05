using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryMenager : MonoBehaviour
{
    public static InventoryMenager instance = null;
    [SerializeField] private List<InventoryItem> items = new List<InventoryItem>();

    private void Start()
    {
        if (instance == null)
        { instance = this; }
    }

    public void AddItem(GameObject gameObject, string nameObg)
    {        
        if (FindItem(nameObg))
        {
            InventoryItem itemFind = items.Find(item => item.nameItem == nameObg.Trim());
            itemFind.countItem += 1;
        }
        else
        {
            InventoryItem newItem = new InventoryItem(gameObject, nameObg.Trim());
            items.Add(newItem);
        }        
        Destroy(gameObject);
    }

    public void DeleteItem (string nameObg)
    {        
        InventoryItem itemFind = items.Find(item => item.nameItem == nameObg.Trim());
        if (itemFind != null)
        {
            if (itemFind.countItem > 1) 
                itemFind.countItem -= 1;
            else
                items.Remove(itemFind);
        }
        else
        {
            Debug.Log("Объект не найден");
        }
    }

    public bool DeleteItems (Dictionary<string, int> itemsQuest)
    {
        int cout = 0;
        foreach (string item in itemsQuest.Keys)
        {
            if (InventoryMenager.instance.FindItem(item))
            {
                InventoryItem itemFind = items.Find(itemfind => itemfind.nameItem == item.Trim());
                if (itemFind.countItem)
                cout++;
            }
            //if (cout == itemsQuest.Length)
            //{
            //    return true;
            //}
        }
        return false;
    }

    public bool FindItem(string nameObg)
    {
        InventoryItem itemFind = items.Find(item => item.nameItem == nameObg.Trim());
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

    public bool FindItams(string[] itemsQuest)
    {
        int cout = 0;
        foreach (var item in itemsQuest)
        {
            if (InventoryMenager.instance.FindItem(item))
            {
                cout++;
            }
            if (cout == itemsQuest.Length)
            {
                return true;
            }
        }
        return false;
    }
}
