using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlavMenuButton : MonoBehaviour
{
    void Start()
    {
        Button vGlavBenuButton = GetComponent<Button>();

        if (vGlavBenuButton != null)
        {
            vGlavBenuButton.onClick.AddListener(GoToGlavMenuScene);
        }
        else
        {
            Debug.LogError("Exit button not found!");
        }
    }


    // Метод, вызываемый при нажатии кнопки
    public void GoToGlavMenuScene()
    {
        // Переходим на следующую сцену
        SceneManager.LoadScene(0);
    }
}
