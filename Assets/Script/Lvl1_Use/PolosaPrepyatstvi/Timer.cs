using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText; // Ссылка на UI текст для отображения времени
    private Coroutine timerCoroutine; // Хранит ссылку на корутину таймера
    private int seconds = 0; // Хранит общее количество секунд
    
    public void StartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // Остановить предыдущий таймер, если он запущен
        }
        seconds = 0; // Сбросить время
        timerText.gameObject.SetActive(true); // Активировать текст
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // Остановить таймер
            timerCoroutine = null; // Обнулить ссылку на корутину
        }
    }

    public int ReturnTimerSeconds()
    {        
        return seconds;
    }

    public void ResetTimer()
    {
        StopTimer(); // Остановить текущий таймер
        seconds = 0; // Сбросить время
        UpdateTimerText(); // Обновить текст
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            seconds++;
            UpdateTimerText(); // Обновить текст каждую секунду
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateTimerText()
    {
        int min = seconds / 60; // Вычислить минуты
        int sec = seconds % 60; // Вычислить секунды
        timerText.text = $"{min:D2}:{sec:D2}"; // Форматирование времени
    }
}

