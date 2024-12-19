using UnityEngine;
using UnityEngine.UI;


//���� ��� ������ � ������� ������
public class QuestsBoard : MonoBehaviour
{
    public Text taskTextPrefab;
    public Transform taskListPanel;

    // ����� ��� ���������� ������� �� �����
    public void AddTaskToBoard(Quest task)
    {
        Text newTaskText = Instantiate(taskTextPrefab, taskListPanel);
        newTaskText.text = task.textQuest + " - " + task.statusQuest;
    }

    // ����� ��� ���������� ������� ������� �� �����
    public void UpdateTaskStatusOnBoard(Quest task)
    {
        foreach (Transform taskTextTransform in taskListPanel)
        {
            Text taskText = taskTextTransform.GetComponent<Text>();
            if (taskText.text.Contains(task.textQuest))
            {
                taskText.text = task.textQuest + " - " + task.statusQuest;
            }
        }
    }

    // ����� ��� �������� ������� ������� �� �����
    public void RemoveTaskFromBoard(Quest task)
    {
        foreach (Transform taskTextTransform in taskListPanel)
        {
            Text taskText = taskTextTransform.GetComponent<Text>();
            if (taskText.text.Contains(task.textQuest))
            {
                Destroy(taskText.gameObject);
                GameObject go = taskTextTransform.gameObject;
                Destroy(go);
                break;
            }
        }
    }    
}
