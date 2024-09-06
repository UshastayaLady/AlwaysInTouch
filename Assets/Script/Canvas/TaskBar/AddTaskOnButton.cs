using UnityEngine;

public class AddTaskOnButton : MonoBehaviour
{
    [SerializeField] private string textQuest;
    public void AddTask()
    {
        TaskBoardManager.instance.AddTask(textQuest);
    }
}
