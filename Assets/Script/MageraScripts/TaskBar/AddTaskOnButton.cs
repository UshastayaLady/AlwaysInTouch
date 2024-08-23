using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddTaskOnButton : MonoBehaviour
{
    public string taskName;
    
    public void AddTask()
    {
        TaskBoardManager.instance.AddTask(taskName);
    }
}
