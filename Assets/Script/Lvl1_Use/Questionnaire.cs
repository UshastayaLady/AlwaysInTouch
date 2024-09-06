using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;

public class Questionnaire : MonoBehaviour
{
    [SerializeField] private GameObject anketa;
    [SerializeField] private Text text_name_reg, text_sename_reg;
    [SerializeField] private Text text_name, text_sename;
    [SerializeField] private Text size1, size2;

    void Update()
    {
        if (TaskBoardManager.instance.FindTaskFromBoard("Заполнить бумаги"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anketa.SetActive(true);
                CursorManager.instance.cursorWork = true;
            }

        }
        else
            anketa.SetActive(false);
                
        bool parametr1 = Regex.IsMatch(size1.text, @"^[0-9]+$");
        bool parametr2 = Regex.IsMatch(size2.text, @"^[0-9]+$");
        bool parametr3 = size1.text.Length > 1 & size1.text.Length < 3;
        bool parametr4 = size2.text.Length > 1 & size2.text.Length < 3;

        if (text_name.text.Trim() == text_name_reg.text & text_sename.text.Trim() == text_sename_reg.text)
        {
            if (parametr1 & parametr2 & parametr3 & parametr4)
                TaskBoardManager.instance.UpdateTaskStatus("Заполнить бумаги", "Выполнен");
        }
    }
}
