using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PolosaStart : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject player, canvasStart, countingDown, finishMarker;
    [SerializeField] private GameObject triggersRules, triggersLimitations;
    [SerializeField] private Transform spawn;
    [SerializeField] private Text countingDownText;
    private FirstPersonController FPS;
    private void Start()
    {
        FPS = FindObjectOfType<FirstPersonController>();
    }
    public void Restart()
    {    
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
    }
    private void StartPolosa()
    {
        triggersLimitations.SetActive(true);
        finishMarker.SetActive(true);
        Restart();
        StartCoroutine(CountingDown());
    }
    public void WorkoutStripe()
    {
        triggersRules.SetActive(true);
        StartPolosa();
    }

    public void TestStripe()
    {
        StartPolosa();
        timer.StartTimer();
    }

    private IEnumerator CountingDown()
    {
        FPS.enabled = false;
        float time = 3f;
        countingDown.SetActive(true);
        while (time >= 0)
        {
            countingDownText.text = time.ToString("F0"); // Убираем знаки после запятой
            yield return new WaitForSeconds(Time.deltaTime); // Ждем один кадр
            time -= Time.deltaTime;
        }
        countingDown.SetActive(false);
        FPS.enabled = true;
    }       
}