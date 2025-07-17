using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText; // ������ �� UI ����� ��� ����������� �������
    private Coroutine timerCoroutine; // ������ ������ �� �������� �������
    private int seconds = 0; // ������ ����� ���������� ������
    
    public void StartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // ���������� ���������� ������, ���� �� �������
        }
        seconds = 0; // �������� �����
        timerText.gameObject.SetActive(true); // ������������ �����
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // ���������� ������
            timerCoroutine = null; // �������� ������ �� ��������
        }
    }

    public int ReturnTimerSeconds()
    {        
        return seconds;
    }

    public void ResetTimer()
    {
        StopTimer(); // ���������� ������� ������
        seconds = 0; // �������� �����
        UpdateTimerText(); // �������� �����
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            seconds++;
            UpdateTimerText(); // �������� ����� ������ �������
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateTimerText()
    {
        int min = seconds / 60; // ��������� ������
        int sec = seconds % 60; // ��������� �������
        timerText.text = $"{min:D2}:{sec:D2}"; // �������������� �������
    }
}

