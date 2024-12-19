using UnityEngine;
using UnityEngine.UI;

public class NpsWeaponRezult : MonoBehaviour
{
    [SerializeField] private GameObject textNavigation3;
    [SerializeField] private GameObject buttonE;
    [SerializeField] private GameObject rezultImage;
    [SerializeField] private Text six, seven, eight, nine, ten, sum;
    [SerializeField] private GreenTarget GreenTarget;
    private bool enter;
    private SupplyPointTrigger supplyPointTrigger;
    [SerializeField] private GameObject neSdal;
    [SerializeField] private GameObject sdal;
    [SerializeField] private GameObject chekTwoQuests;

    void Update()
    {
        if(enter && Input.GetKeyDown(KeyCode.E))
        {
            textNavigation3.SetActive(false);
            buttonE.SetActive(false);
            six.text = "Попаданий в '6': " + GreenTarget.six;
            seven.text = "Попаданий в '7': " + GreenTarget.sev;
            eight.text = "Попаданий в '8': " + GreenTarget.vos;
            nine.text = "Попаданий в '9': " + GreenTarget.nine;
            ten.text = "Попаданий в '10': " + GreenTarget.ten;
            sum.text = GreenTarget.scores + " очков";
            rezultImage.SetActive(true);

            if (GreenTarget.scores > 80)
            {
                sdal.SetActive(false);
                QuestsManager.instance.UpdateTaskStatus("Сдать зачет по стрельбе", "Выполнен");
                if (QuestsManager.instance.FindStatusTaskFromBoard("Сдать зачет по прохождению полосы препятствий", "Выполнен"))
                {
                    chekTwoQuests.SetActive(true);
                    QuestsManager.instance.TaskEndAndDelete("Сдать зачет по стрельбе");
                    QuestsManager.instance.TaskEndAndDelete("Сдать зачет по прохождению полосы препятствий");
                    QuestsManager.instance.AddTask("Сдать результаты зачетов командиру");
                }
                    
                this.enabled = false;                
            }
            else 
            {
                neSdal.SetActive(true);
                supplyPointTrigger = FindObjectOfType<SupplyPointTrigger>();
                supplyPointTrigger.one = true;
                gameObject.GetComponent<SphereCollider>().enabled = false;
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { enter = true; buttonE.SetActive(true); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") { enter = false; buttonE.SetActive(false); }
    }
}
