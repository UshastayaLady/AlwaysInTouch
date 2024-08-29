using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;

    void Start()
    {
        resolutionDropdown = GetComponent<Dropdown>();
            
        resolutionDropdown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
                
        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + "x" + resolution.height;
            resolutionDropdown.options.Add(new Dropdown.OptionData(option));
        }
               
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionDropdownValueChanged(); });

        // Устанавливаем начальное значение выпадающего списка
        resolutionDropdown.value = GetCurrentResolutionIndex();
    }

    // Метод, вызываемый при изменении выбранной опции в выпадающем списке
    void OnResolutionDropdownValueChanged()
    {
        // Получаем выбранное разрешение из списка
        Resolution chosenResolution = Screen.resolutions[resolutionDropdown.value];

        // Изменяем разрешение экрана
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreen);
    }

    // Метод для получения индекса текущего разрешения экрана
    int GetCurrentResolutionIndex()
    {
        Resolution currentResolution = Screen.currentResolution;

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].width == currentResolution.width &&
                Screen.resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }

        return -1;
    }
}
