using UnityEngine.UI;
using UnityEngine;

public class Registration : MonoBehaviour
{    
    private FirstPersonController FPS;

    [SerializeField] private GameObject Registr;
    [SerializeField] private Text text_name, text_sename;
    [SerializeField] private Text text_name_reg, text_sename_reg;
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
        if (col.tag == "Player")
        {            
            CursorMenager.instance.cursorWork = true;            
        }
    }

    public void Continious()
    {
        text_name_reg.text = text_name.text;
        text_sename_reg.text = text_sename.text;
        Person.SetActive(true);               
        Registr.SetActive(false);
        zapuskRaz = true;
        FPS.setFreeze(false);
        CursorMenager.instance.cursorWork = false;
        DialogueManager.instance.StartDialogue();
    } 
}
