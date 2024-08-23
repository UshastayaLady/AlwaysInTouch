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


    //public Text questStatus;
    //public GameObject questPrefab;
    //public GameObject scrollViewPrefab;
    //public GameObject[] questsPrefab;

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
            // Переключаем состояние объекта
            taskBoardPrefab.SetActive(!taskBoardPrefab.activeSelf);
        }
    }
    // Метод для добавления нового задания на доску
    public void AddTask(string questText)
    {
        Task newTask = new Task(questText);
        tasks.Add(newTask);
        taskBoard.AddTaskToBoard(newTask);

        //// Создаем новый экземпляр Text
        //GameObject newText = Instantiate(questPrefab);

        //// Устанавливаем родителем для нового текста Scroll View
        //newText.transform.SetParent(scrollViewPrefab.transform, false);

        //// Добавляем текст в новый объект Text
        //newText.GetComponent<Text>().text = questText;

        //questsPrefab.Append(newText);

        //InstantiateDialogue.instance.changeDialogue();
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
