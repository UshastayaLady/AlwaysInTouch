using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using static Strings;

public class Registration : MonoBehaviour
{
    private CursorMenager cursorMenager;
    public GameObject Registr;
    public FirstPersonController FPS;    
    public Text text_name, text_fename;
    public Text text_name_reg, text_fename_reg;
    public GameObject Name, Fename;
    // Start is called before the first frame update
    private void Start()
    {
        cursorMenager = FindObjectOfType<CursorMenager>();
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {            
            FPS.setFreeze(true);
            Registr.SetActive(true);
            cursorMenager.cursorWork = true;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //  script.GetComponent<>();
        }
    }

    public void Continious()
    {
        text_name_reg.text = text_name.text;
        text_fename_reg.text = text_fename.text;
        Name.SetActive(true);
        Fename.SetActive(true);        
        Registr.SetActive(false);
        FPS.setFreeze(false);        
        cursorMenager.cursorWork = false;
        Achievements achievement = FindObjectOfType<Achievements>();
        achievement.showAchieve(Strings.registration, 0);
    } 
}
