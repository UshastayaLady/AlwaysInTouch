using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        Button exitButton = GetComponent<Button>();
                
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogError("Exit button not found!");
        }
    }

    // Метод для выхода из игры
    void ExitGame()
    {
        Application.Quit();
    }
}
