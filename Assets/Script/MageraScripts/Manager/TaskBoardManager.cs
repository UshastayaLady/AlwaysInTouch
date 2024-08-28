using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System;
using UnityEngine.UI;

//���� ��� ������ � ��������
public class TaskBoardManager : MonoBehaviour
{
    public static TaskBoardManager instance;

    public GameObject taskBoardPrefab;
    public TaskBoard taskBoard;
    public List<Task> tasks = new List<Task>();

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
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // ����������� ��������� �������
            taskBoardPrefab.SetActive(!taskBoardPrefab.activeSelf);
        }
    }
    // ����� ��� ���������� ������ ������� �� �����
    public void AddTask(string questText)
    {
        questText = questText.Trim();
        Task newTask = new Task(questText, "�� ��������");
        tasks.Add(newTask);
        taskBoard.AddTaskToBoard(newTask);

    }

    // ����� ��� ���������� ������� �������
    public void UpdateTaskStatus(string questText, string newStatus)
    {
        questText = questText.Trim();
        newStatus = newStatus.Trim();
        Task taskToUpdate = tasks.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            taskToUpdate.statusQuest = newStatus;
            taskBoard.UpdateTaskStatusOnBoard(taskToUpdate);
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }
    public void TaskDone(string questText, string status)
    {
        questText = questText.Trim();
        Task taskToUpdate = tasks.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            if (taskToUpdate.statusQuest == status)
            {
                taskBoard.RemoveTaskFromBoard(taskToUpdate);
            }
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }

    public void TaskDoneDialogue(string questText)
    {
        questText = questText.Trim();
        Task taskToUpdate = tasks.Find(task => task.textQuest == questText);
        if (taskToUpdate != null)
        {
            taskBoard.RemoveTaskFromBoard(taskToUpdate);
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }

}
