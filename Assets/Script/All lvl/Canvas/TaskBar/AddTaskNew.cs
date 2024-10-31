using UnityEngine;

public class AddTaskNew : MonoBehaviour
{
    [SerializeField] private string [] textQuest;
    [SerializeField] private bool noButton = false;
    private bool one = true;

    private void Update()
    {
        if (noButton & one)
        {
            AddTask();
            one = false;
        }
    }
    public void AddTask()
    {
        for (int i = 0; i < textQuest.Length; i++)
        {
            TaskBoardManager.instance.AddTask(textQuest[i]);
        }        
    }
}
