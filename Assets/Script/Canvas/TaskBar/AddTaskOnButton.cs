using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddTaskOnButton : MonoBehaviour
{
    [SerializeField] private string textQuest;
    public void AddTask()
    {
        TaskBoardManager.instance.AddTask(textQuest);
    }
}
