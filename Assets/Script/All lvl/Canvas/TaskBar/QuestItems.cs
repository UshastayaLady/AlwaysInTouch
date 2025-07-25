using System.Collections.Generic;
using UnityEngine;

public class QuestItems : MonoBehaviour
{
    [System.Serializable]
    public class QuestItem
    {
        public string itemName;
        public int itemCount;
    }
    [SerializeField] private List<QuestItem> itemsQuestList;
    private Dictionary <string, int> itemsQuest;

    [SerializeField] bool changeQuest = false;
    [SerializeField] bool changeStatus = false;
    [SerializeField] bool deleteQuest = false;
    [SerializeField] bool destroyGameObject = false;
    [SerializeField] private string questText;
    [SerializeField] private string questNextText;

    void Start()
    {
        itemsQuest = new Dictionary<string, int>();
        foreach (var questItem in itemsQuestList)
        {
            itemsQuest[questItem.itemName] = questItem.itemCount;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (questText != null & QuestsManager.instance.FindTaskFromBoard(questText))
            if (InventoryManager.instance.FindItems(itemsQuest))
                if (changeQuest & questNextText != null)
                {
                    InventoryManager.instance.DeleteItems(itemsQuest);
                    QuestsManager.instance.TaskEndAndDelete(questText.Trim());
                    QuestsManager.instance.AddTask(questNextText.Trim());
                    DestroyObject();
                }
                else if (changeStatus)
                {
                    InventoryManager.instance.DeleteItems(itemsQuest);
                    QuestsManager.instance.UpdateTaskStatus(questText.Trim(), "��������");
                    DestroyObject();
                }        
    }

    private void DestroyObject()
    {
        if (deleteQuest)
        {
            QuestsManager.instance.TaskDone(questText.Trim(), "��������");
        }
        if (destroyGameObject)
            Destroy(this.gameObject);
        else Destroy(this);
    }
}
