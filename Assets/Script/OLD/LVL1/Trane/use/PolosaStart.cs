using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PolosaStart : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject player, canvasStart, countingDown;
    [SerializeField] private GameObject triggersRules, triggersLimitations;
    [SerializeField] private Transform spawn;
    [SerializeField] private Text countingDownText;
      
    public void Restart()
    {    
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
    }

    public void WorkoutStripe()
    {
        triggersRules.SetActive(true);
        triggersLimitations.SetActive(true);
        Restart();
        StartCoroutine(CountingDown()); 
    }

    public void TestStripe()
    {              
        triggersLimitations.SetActive(true);
        Restart();
        StartCoroutine(CountingDown());
        timer.StartTimer();
    }

    private IEnumerator CountingDown()
    {
        PlayerManager.instance.PlayerFreezTrue();
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