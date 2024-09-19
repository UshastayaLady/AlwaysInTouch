using UnityEngine;

public class DeleteTask : MonoBehaviour
{

    [SerializeField] private string[] textQuest;
    [SerializeField] private bool noButton = false;
    private bool one = true;

    private void Update()
    {
        if (noButton & one)
        {
            DelTask();
            one = false;
        }
    }
    public void DelTask()
    {
        for (int i = 0; i < textQuest.Length; i++)
        {
            TaskBoardManager.instance.TaskEndAndDelete(textQuest[i]);
        }
    }
}
