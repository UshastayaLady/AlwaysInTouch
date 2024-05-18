using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddTaskOnEvent : MonoBehaviour
{
    public string taskName;
    public UnityEvent onEvent;

    private void OnEnable()
    {
        onEvent.AddListener(AddTask);
    }

    private void OnDisable()
    {
        onEvent.RemoveListener(AddTask);
    }

    private void AddTask()
    {
        TaskBoardManager.instance.AddTask(taskName);
    }
}
