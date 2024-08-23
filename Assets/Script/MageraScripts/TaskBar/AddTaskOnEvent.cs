using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddTaskOnEvent : MonoBehaviour
{
    public string taskName;
    public UnityEvent onEvent;

    private void OnTriggerEnter(Collider other)
    {
        onEvent.AddListener(AddTask);
    }

    private void OnTriggerExit(Collider other)
    { 
        onEvent.RemoveListener(AddTask);
    }

    private void AddTask()
    {
        TaskBoardManager.instance.AddTask(taskName);
    }
}
