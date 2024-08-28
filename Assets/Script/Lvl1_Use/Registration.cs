using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using static Strings;

public class Registration : MonoBehaviour
{
    private CursorMenager cursorMenager;
    public FirstPersonController FPS;

    public GameObject Registr;    
    public Text text_name, text_sename;
    public Text text_name_reg, text_sename_reg;
    public GameObject Person;

    
    private void Start()
    {
        cursorMenager = FindObjectOfType<CursorMenager>();
    }
    
    private void OnTriggerEnter(Collider col)
    {
        //if (col.tag == "Player")
        //{            
        //    FPS.setFreeze(true);
        //    Registr.SetActive(true);         
        //}
    }

    private void OnTriggerStay(Collider col)
    {
        if (TaskBoardManager.instance.FindTaskFromBoard("Регистрация"))
        {
            if (col.tag == "Player")
            {
                FPS.setFreeze(true);
                Registr.SetActive(true);
            }
        }
        if (col.tag == "Player")
        {            
            cursorMenager.cursorWork = true;            
        }
    }

    public void Continious()
    {
        text_name_reg.text = text_name.text;
        text_sename_reg.text = text_sename.text;
        Person.SetActive(true);               
        Registr.SetActive(false);
        FPS.setFreeze(false);        
        cursorMenager.cursorWork = false;
        //Achievements achievement = FindObjectOfType<Achievements>();
        //achievement.showAchieve(Strings.registration, 0);
    } 
}
