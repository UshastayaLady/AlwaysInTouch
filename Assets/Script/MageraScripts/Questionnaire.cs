using UnityEngine.UI;
using UnityEngine;

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
                CursorMenager.instance.cursorWork = true;
            }            

        }            
        else
            anketa.SetActive(false);

        if (text_name == text_name_reg & text_sename == text_sename_reg)
        {
            //if (size1 )
            TaskBoardManager.instance.UpdateTaskStatus("Заполнить бумаги", "Выполнен");
        }
    }
}
