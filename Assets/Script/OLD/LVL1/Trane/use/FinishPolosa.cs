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
            if (triggersRules.activeSelf)
            {
                triggersRules.SetActive(false);
                canvasFinishWorkout.SetActive(true);
            }
            else 
            {
                timer.StopTimer();
                canvasFinishTest.SetActive(true);
            }
            triggersLimitations.SetActive(false);
            triggerStart.SetActive(true);
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.instance.PlayerFreezTrue();
            enter = true;          
        }
    }
}
