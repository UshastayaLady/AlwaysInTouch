using UnityEngine;
using UnityEngine.UI;

public class WeaponRezult : MonoBehaviour
{
    [SerializeField] private GameObject textNavigation3;
    [SerializeField] private GameObject buttonE;
    [SerializeField] private GameObject rezultImage;
    [SerializeField] private Text six, seven, eight, nine, ten, sum;
    [SerializeField] private GreenTarget GreenTarget;
    private bool enter;

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

            //Weapon_trigg.ammo_bool = false;
            rezultImage.SetActive(true);
            
            
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
