using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;

public class Questionnaire : MonoBehaviour
{
    [SerializeField] private Text text_name_reg, text_sename_reg;
    [SerializeField] private Text text_name, text_sename;
    [SerializeField] private Text size1, size2;
    [SerializeField] private Button allredy;
    private bool parametr1 = false;
    private bool parametr2 = false;
    private bool parametr3 = false;
    private bool parametr4 = false;
   
    private void Update()
    {
        parametr1 = Regex.IsMatch(size1.text, @"^[0-9]+$");
        parametr2 = Regex.IsMatch(size2.text, @"^[0-9]+$");
        parametr3 = size1.text.Length == 2 && size2.text.Length == 2;
        parametr4 = text_name.text.Trim().ToLower() == text_name_reg.text.Trim().ToLower() && text_sename.text.Trim().ToLower() == text_sename_reg.text.Trim().ToLower();
        allredy.onClick.AddListener(ProverkaAnketa);
    }
    private void ProverkaAnketa()
    {
        if (parametr1 & parametr2 & parametr3 & parametr4)
            TaskBoardManager.instance.UpdateTaskStatus("��������� ������", "��������");
        else TaskBoardManager.instance.UpdateTaskStatus("��������� ������", "�� ��������");
    }
}
