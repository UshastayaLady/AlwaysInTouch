using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoardManager : MonoBehaviour
{
    public static TaskBoardManager instance;

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

    // Метод для добавления нового задания на доску
    public void AddTask(string taskName)
    {
        Task newTask = new Task(taskName);
        tasks.Add(newTask);
        taskBoard.AddTaskToBoard(newTask);
    }

    // Метод для обновления статуса задания
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
            Debug.Log("Задание не найдено");
        }
    }
}
