using UnityEngine;
using UnityEngine.UI;

public class WeaponRezult : MonoBehaviour
{
    [SerializeField] private GameObject rezult, rezult_text, rezult_text_finish;
    [SerializeField] private Text six, seven, eight, nine, ten, sum;
    [SerializeField] private GreenTarget GreenTarget;
    bool enter;

    void Update()
    {
        if(enter && Input.GetKeyDown(KeyCode.E))
        {
            six.text = "Попаданий в '6': " + GreenTarget.six;
            seven.text = "Попаданий в '7': " + GreenTarget.sev;
            eight.text = "Попаданий в '8': " + GreenTarget.vos;
            nine.text = "Попаданий в '9': " + GreenTarget.nine;
            ten.text = "Попаданий в '10': " + GreenTarget.ten;
            sum.text = GreenTarget.scores + " очков";

            Weapon_trigg.ammo_bool = false;
            rezult.SetActive(true);
            rezult_text.SetActive(false);
            rezult_text_finish.SetActive(false);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { enter = true; rezult_text_finish.SetActive(true); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") { enter = false; rezult_text_finish.SetActive(false); }
    }
}
