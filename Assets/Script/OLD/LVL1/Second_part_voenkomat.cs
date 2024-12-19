
using UnityEngine;

public class Second_part_voenkomat : MonoBehaviour
{
    //private CursorManager cursorManager;
    public GameObject Instr;
    public GameObject PolosaQuest, WeaponQUEST;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {            
            Instr.SetActive(true);
        }
    }

    public void Continious()
    {
        Instr.SetActive(false); 
        PolosaQuest.GetComponent<SphereCollider>().enabled = true;
        PolosaQuest.transform.GetChild(0).gameObject.SetActive(true);
        WeaponQUEST.SetActive(true);
    }
}
