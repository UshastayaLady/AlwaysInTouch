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

        // ������������� ��������� �������� ����������� ������
        resolutionDropdown.value = GetCurrentResolutionIndex();
    }

    // �����, ���������� ��� ��������� ��������� ����� � ���������� ������
    void OnResolutionDropdownValueChanged()
    {
        // �������� ��������� ���������� �� ������
        Resolution chosenResolution = Screen.resolutions[resolutionDropdown.value];

        // �������� ���������� ������
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreen);
    }

    // ����� ��� ��������� ������� �������� ���������� ������
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
