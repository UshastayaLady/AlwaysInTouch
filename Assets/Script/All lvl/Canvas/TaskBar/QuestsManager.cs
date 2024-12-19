using System.Collections.Generic;
using UnityEngine;

//���� ��� ������ � ��������
public class QuestsManager : MonoBehaviour
{
    public static QuestsManager instance;
    [SerializeField] private GameObject newQuestInfo;
    [SerializeField] private GameObject questBoardPrefab;
    private QuestsBoard questBoard;
    public List<Quest> quest = new List<Quest>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        questBoard = FindObjectOfType<QuestsBoard>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // ����������� ��������� �������
            questBoardPrefab.SetActive(!questBoardPrefab.activeSelf);
            if (newQuestInfo.activeSelf  && questBoardPrefab.activeSelf)
            {
                newQuestInfo.SetActive(false);
            }
        }
    }
    // ����� ��� ���������� ������ ������� �� �����
    public void AddTask(string questText)
    {
        questText = questText.Trim();
        Quest newTask = new Quest(questText, "�� ��������");
        quest.Add(newTask);
        questBoard.AddTaskToBoard(newTask);
        newQuestInfo.SetActive(true);
    }

    // ����� ��� ���������� ������� �������
    public void UpdateTaskStatus(string questText, string newStatus)
    {
        questText = questText.Trim();
        newStatus = newStatus.Trim();
        Quest taskToUpdate = quest.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            taskToUpdate.statusQuest = newStatus;
            questBoard.UpdateTaskStatusOnBoard(taskToUpdate);
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }
    public void TaskDone(string questText, string questStatus)
    {
        questText = questText.Trim();
        questStatus = questStatus.Trim();
        Quest taskToUpdate = quest.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            if (taskToUpdate.statusQuest == questStatus)
            {
                questBoard.RemoveTaskFromBoard(taskToUpdate);
            }
            else Debug.Log("������ �� ��������");
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }

    public void TaskEndAndDelete(string questText)
    {
        questText = questText.Trim();
        Quest taskToUpdate = quest.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            questBoard.RemoveTaskFromBoard(taskToUpdate);            
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }

    // ����� ��� ������ ������
    public bool FindTaskFromBoard(string questText)
    {
        questText = questText.Trim();
        Quest taskToUpdate = quest.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            return true;
        }
        else
        {            
            Debug.Log("������� �� �������");
            return false;
        }
    }

    public bool FindStatusTaskFromBoard(string questText, string questStatus)
    {
        questText = questText.Trim();
        Quest taskToUpdate = quest.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            if (taskToUpdate.statusQuest == questStatus)
                return true;
            else
                return false;
        }
        else
        {
            Debug.Log("������� �� �������");
            return false;
        }
    }
    
}
