using UnityEngine;
using UnityEngine.UI;


//���� ��� ������ � ������� ������
public class TaskBoard : MonoBehaviour
{
    public Text taskTextPrefab;
    public Transform taskListPanel;

    // ����� ��� ���������� ������� �� �����
    public void AddTaskToBoard(Task task)
    {
        Text newTaskText = Instantiate(taskTextPrefab, taskListPanel);
        newTaskText.text = task.textQuest + " - " + task.statusQuest;
    }

    // ����� ��� ���������� ������� ������� �� �����
    public void UpdateTaskStatusOnBoard(Task task)
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
    public void RemoveTaskFromBoard(Task task)
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
