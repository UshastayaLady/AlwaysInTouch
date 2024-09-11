using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Windows;
using System;

public class Registration : MonoBehaviour
{    
    private FirstPersonController FPS;

    [SerializeField] private GameObject Registr;
    [SerializeField] private GameObject buttonNext;
    [SerializeField] private Text text_name_reg, text_sename_reg;
    [SerializeField] private Text text_name, text_sename;
    [SerializeField] private GameObject Person;

    private void Start()
    {
        CursorManager.instance.cursorWork = true;
        FPS = FindObjectOfType<FirstPersonController>();
        FPS.setFreeze(true);
    }

    private void Update()
    {     

        bool result1 = (Regex.IsMatch(text_name_reg.text, @"^[a-zA-Z]+$")) || (Regex.IsMatch(text_name_reg.text, @"^[à-ÿÀ-ß]+$"));
        bool result2 = (Regex.IsMatch(text_name_reg.text, @"^[a-zA-Z]+$")) || (Regex.IsMatch(text_name_reg.text, @"^[à-ÿÀ-ß]+$"));
        bool result3 = (text_name_reg.text.Length > 0) & (text_name_reg.text.Length < 15);
        bool result4 = (text_sename_reg.text.Length > 0) & (text_sename_reg.text.Length < 15);

        if (result3 & result4 & result1 & result2)        
            buttonNext.SetActive(true);
        else buttonNext.SetActive(false);
    }

    public void Continious()
    {
        text_name.text = text_name_reg.text.Trim();
        text_sename.text = text_sename_reg.text.Trim();
        Person.SetActive(true);               
        Registr.SetActive(false);        
        FPS.setFreeze(false);
        DialogueManager.instance.StartDialogue();
    } 
}
