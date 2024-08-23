using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System;
using UnityEngine.UI;

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
    public void AddTask(string taskName)
    {
        Task newTask = new Task(taskName);
        tasks.Add(newTask);
        taskBoard.AddTaskToBoard(newTask);
    }

    // ����� ��� ���������� ������� �������
    public void UpdateTaskStatus(string taskName, string newStatus)
    {
        Task taskToUpdate = tasks.Find(task => task.taskName == taskName);
        if (taskToUpdate != null)
        {
            taskToUpdate.status = newStatus;
            taskBoard.UpdateTaskStatusOnBoard(taskToUpdate);
        }
        else
        {
            Debug.Log("������� �� �������");
        }
    }
}
