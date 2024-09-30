using UnityEngine;

public class FinishPolosa : MonoBehaviour
{
    bool enter;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject canvasFinishWorkout, canvasFinishTest;
    [SerializeField] private GameObject triggersRules, triggersLimitations;
    [SerializeField] private GameObject triggerStart;
    public Transform spawn;
    private FirstPersonController FPS;
    private void Start()
    {
        FPS = FindObjectOfType<FirstPersonController>();
    }
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
                if (timer.ReturnTimerSeconds() <= 120)
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
            FPS.setFreeze(true);
            enter = true;
            CursorManager.instance.cursorWork = true;
        }
    }
}
