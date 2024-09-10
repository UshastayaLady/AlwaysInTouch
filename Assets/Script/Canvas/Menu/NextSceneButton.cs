using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneButton : MonoBehaviour
{
    void Start()
    {
        Button exitButton = GetComponent<Button>();

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(GoToNextScene);
        }
        else
        {
            Debug.LogError("Exit button not found!");
        }
    }


    // �����, ���������� ��� ������� ������
    public void GoToNextScene()
    {
        // �������� ������ ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� �� ��������� �����
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}