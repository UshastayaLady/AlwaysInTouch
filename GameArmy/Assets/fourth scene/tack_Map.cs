using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tack_Map : MonoBehaviour
{
    private bool enter;
    [SerializeField] GameObject map;
    [SerializeField] GameObject mini_map;
    [SerializeField] GameObject kompas;

    [SerializeField] GameObject score_text;
    [SerializeField] GameObject time_text;

    [SerializeField] GameObject tack_Map_Trigger;

    [SerializeField] GameObject start_Timer_Trigger;

    [SerializeField] Text Help_Text;

    public bool map_activate = false;

    void Update()
    {
        if (enter == true)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                map_activate = true;
                start_Timer_Trigger.SetActive(true);
                score_text.SetActive(true);
                time_text.SetActive(true);
                map.SetActive(false);
                kompas.SetActive(false);
                mini_map.SetActive(true);
                Help_Text.enabled = false;
                tack_Map_Trigger.SetActive(false);
            }

            Help_Text.text = string.Format("Нажмите Е, чтобы подобрать карту.");

        }

        if (enter == false)
        {
            Help_Text.text = string.Format("");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "nikitich")
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.name == "nikitich")
        {
            enter = false;
        }
    }
}
