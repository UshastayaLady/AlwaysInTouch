using UnityEngine;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager instance; // ������ �� ������������ ��������� ����� ������
    public float globalVolume = 1.0f; // ���������� ��������� �� ���������

    void Awake()
    {
        // ���������, ���������� �� ��� ��������� ������
        if (instance == null)
        {
            // ���� ���, �� ������ ���� ��������� �������
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ���� ������ ��� �������� ����� �����
        }
        else
        {
            // ���� ��� ���������� ��������� ������, ���������� ���� ������
            Destroy(gameObject);
        }
    }
}

