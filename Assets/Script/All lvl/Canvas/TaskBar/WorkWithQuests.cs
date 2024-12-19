using UnityEngine;

public class WorkWithQuests : MonoBehaviour
{
    [SerializeField] private bool addQuests = false;
    [SerializeField] private bool delQuests = false;
    [SerializeField] private bool changStatus = false;
    [SerializeField] private bool chengQuests = false;
    [SerializeField] private bool dontChekStutusFoActivObject = false;
    [SerializeField] private bool activObject  = false;
    
    [SerializeField] private string[] textQuest;
    [SerializeField] private string[] addQuest;
    [SerializeField] private string[] delQuest;
    [SerializeField] private string[] newTextQuest;
    [SerializeField] private GameObject [] objectAktive;

    [SerializeField] private bool noButton = false;

    private bool one = true;

    private void Update()
    {
        if (noButton & one)
        {
            if (activObject)
                SetAktivObgectMassiv();
            if (addQuests)
                AddTaskMassiv();
            if (delQuests)
                DelTaskMassiv();
            if (changStatus)
                ChengStatusMassiv();
            if (chengQuests)
                ChengQuestsMassiv();           
            one = false;
        }
    }

    public void SetAktivObgectMassiv()
    {
        for (int i = 0; i < textQuest.Length; i++)
        {
            if (QuestsManager.instance.FindTaskFromBoard(textQuest[i]))
            {
                if (dontChekStutusFoActivObject || QuestsManager.instance.FindStatusTaskFromBoard(textQuest[i], "Выполнен"))
                {
                    for (int k = 0; k < objectAktive.Length; k++)
                        objectAktive[k].SetActive(!objectAktive[k].activeSelf);
                }
            }
        }
    }

    public void ChengQuestsMassiv()
    {
        for (int i = 0; i < textQuest.Length; i++)
        {
            if (QuestsManager.instance.FindTaskFromBoard(textQuest[i]))
            {
                QuestsManager.instance.TaskEndAndDelete(textQuest[i]);
                QuestsManager.instance.AddTask(newTextQuest[i]);
            }
        }
    }

    public void ChengStatusMassiv()
    {
        for (int i = 0; i < textQuest.Length; i++)
        {
            QuestsManager.instance.UpdateTaskStatus(textQuest[i], "Выполнен");
        }
    }

    public void AddTaskMassiv()
    {
        for (int i = 0; i < addQuest.Length; i++)
        {
            QuestsManager.instance.AddTask(addQuest[i]);
        }
    }

    public void DelTaskMassiv()
    {
        for (int i = 0; i < delQuest.Length; i++)
        {
            QuestsManager.instance.TaskEndAndDelete(delQuest[i]);
        }
    }
}
