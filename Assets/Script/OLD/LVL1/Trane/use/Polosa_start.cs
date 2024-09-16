using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Polosa_start : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject player, canvasStart, countingDown;
    [SerializeField] private GameObject triggersRules, triggersLimitations;   
    public bool startPolosa = false;
    private bool finishPolosa = false;
    [SerializeField] private Transform spawn;
    [SerializeField] private Text countingDownText;


    private bool workout;
    private bool test;

    void Start()
    {
        PlayerManager.instance.PlayerFreezTrue();
        CursorManager.instance.cursorWork = true;
        canvasStart.SetActive(true);
        workout = false;
        test = false;        
    }

    public void Restart()
    {    
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")) 
    //    {
    //        finishPolosa = true;
    //        Workout();
    //    }
    //}

    public void WorkoutStripe()
    {
        workout = true;
        triggersRules.SetActive(true);
        triggersLimitations.SetActive(true);
        Restart();
        StartCoroutine(CountingDown()); 
    }

    public void TestStripe()
    {
        test = true;        
        triggersLimitations.SetActive(true);
        Restart();
        StartCoroutine(CountingDown());
        timer.StartTimer();
    }

    private IEnumerator CountingDown()
    {
        float time = 3f;
        countingDown.SetActive(true);
        while (time >= 0)
        {
            countingDownText.text = time.ToString("F0"); // Убираем знаки после запятой
            yield return new WaitForSeconds(Time.deltaTime); // Ждем один кадр
            time -= Time.deltaTime;
        }
        countingDown.SetActive(false);
        PlayerManager.instance.PlayerFreezFalse();
    }       
}