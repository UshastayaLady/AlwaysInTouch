using UnityEngine;

public class FinishPolosa : MonoBehaviour
{
    bool enter;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject canvasFinishWorkout, canvasFinishTest;
    [SerializeField] private GameObject triggersRules, triggersLimitations;
    [SerializeField] private GameObject triggerStart;
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
                    TaskBoardManager.instance.UpdateTaskStatus("Сдать зачет по прохождению полосы препятствий", "Выполнен");
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
