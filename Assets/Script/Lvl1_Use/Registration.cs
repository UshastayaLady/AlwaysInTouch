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
    private bool zapuskRaz=false;

    private void Start()
    {        
        FPS = FindObjectOfType<FirstPersonController>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (TaskBoardManager.instance.FindTaskFromBoard("Регистрация") & !zapuskRaz)
        {
            if (col.tag == "Player")
            {
                FPS.setFreeze(true);
                Registr.SetActive(true);
                TaskBoardManager.instance.TaskEndAndDelete("Регистрация");
            }
        }
        bool result1 = (Regex.IsMatch(text_name_reg.text, @"^[a-zA-Z]+$")) & (text_name_reg.text.Length< 20);
        bool result2 = (Regex.IsMatch(text_sename_reg.text, @"^[a-zA-Z]+$")) &(text_name_reg.text.Length < 20);
        if (text_name_reg.text.Length > 0 & text_sename_reg.text.Length > 0 & result1 & result2)        
            buttonNext.SetActive(true);
        else buttonNext.SetActive(false);
    }

    public void Continious()
    {
        text_name.text = text_name_reg.text.Trim();
        text_sename.text = text_sename_reg.text.Trim();
        Person.SetActive(true);               
        Registr.SetActive(false);
        zapuskRaz = true;
        FPS.setFreeze(false);
        DialogueManager.instance.StartDialogue();
    } 
}
