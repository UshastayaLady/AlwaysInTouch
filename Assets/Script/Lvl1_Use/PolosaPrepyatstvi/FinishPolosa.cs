using UnityEngine;

public class FinishPolosa : MonoBehaviour
{
    bool enter;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject canvasFinishWorkout, canvasFinishTest;
    [SerializeField] private GameObject triggersRules, triggersLimitations;
    [SerializeField] private GameObject triggerStart;
    [SerializeField] private GameObject chekTwoQuests;
    public Transform spawn;
   
    public void Update()
    {
        if(enter == true)
        {
            enter = false;
            if (triggersRules.activeSelf)
            {
                triggersRules.SetActive(false);
                canvasFinishWorkout.SetActive(true);
                triggerStart.SetActive(true);
            }
            else 
            {
                timer.StopTimer();
                if (timer.ReturnTimerSeconds() <= 200)
                {
                    QuestsManager.instance.UpdateTaskStatus("Сдать зачет по прохождению полосы препятствий", "Выполнен");
                    if (QuestsManager.instance.FindStatusTaskFromBoard("Сдать зачет по стрельбе", "Выполнен"))
                    {
                        chekTwoQuests.SetActive(true);
                        QuestsManager.instance.TaskEndAndDelete("Сдать зачет по стрельбе");
                        QuestsManager.instance.TaskEndAndDelete("Сдать зачет по прохождению полосы препятствий");
                        QuestsManager.instance.AddTask("Сдать результаты зачетов камандиру");
                    }                        
                }
                    

                else
                {
                    triggerStart.SetActive(true);
                }

                canvasFinishTest.SetActive(true);
            }
            triggersLimitations.SetActive(false);            
        }        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
        }
    }
}
