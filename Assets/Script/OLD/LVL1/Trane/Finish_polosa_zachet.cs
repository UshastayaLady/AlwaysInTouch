using UnityEngine;
using UnityEngine.UI;

public class Finish_polosa_zachet : MonoBehaviour
{
    //int fin_sec, fin_min;
    //public Text score;
    //public static bool enter;
    //public Text Text_time;
    //public Transform spawn;
    //public GameObject rezult;
    
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Player" && Polosa_start.trennirovka == false)
//        {
//            GameObject man;
//            man = GameObject.FindGameObjectWithTag("Player");
//            man.GetComponent<FirstPersonController>().enabled = false;

//            enter = true;

//            fin_sec = Polosa_start.sec;
//            fin_min = Polosa_start.min;

//            rezult.SetActive(true);

//            Cursor.lockState = CursorLockMode.None;
//            Cursor.visible = true;

//            Polosa_start.start = false;
//            Polosa_start.koef = 3;

//            GameObject stena;
//            stena = GameObject.FindGameObjectWithTag("stena");
//            stena.GetComponent<Ladder>().enabled = false;

//            score.text = Polosa_start.score.ToString();

//            GameObject timerText;
//            timerText = GameObject.Find("timer");
//            timerText.gameObject.SetActive(false);
//            gameObject.SetActive(false);
//            Text_time.text = fin_min.ToString("D2") + ":" + fin_sec.ToString("D2");
//        }
//    }

//    public void Zanovo()
//    {
//        GameObject man;
//        man = GameObject.FindGameObjectWithTag("Player");
//        man.transform.position = Vector3.MoveTowards(man.transform.position, spawn.position, 100f);
//        //Cursor.lockState = CursorLockMode.Locked;
//        fin_sec = Polosa_start.sec = 0;
//        fin_min = Polosa_start.min = 0;
//        Polosa_start.score = 1500;
//        Cursor.lockState = CursorLockMode.Locked;
//        // Canvas_finish.SetActive(false);
//    }


//    public void Zakonchit()
//    {
//        GameObject man;
//        man = GameObject.FindGameObjectWithTag("Player");
//        man.GetComponent<FirstPersonController>().enabled = true;

//        GameObject stena;
//        stena = GameObject.FindGameObjectWithTag("stena");
//        stena.GetComponent<Ladder>().enabled = false;

//        for (int i = 0; i < Polosa_start.triggers.Length; i++)
//        {
//            Polosa_start.triggers[i].SetActive(false);

//        }
//        for (int i = 0; i < Polosa_start.polosa.Length; i++)
//        {
//            Polosa_start.polosa[i].enter = false;
//        }
//        for (int i = 0; i < Polosa_start.instr.Length; i++)
//        {
//            Polosa_start.instr[i].SetActive(false);
//        }
//        enter = false;
//        rezult.SetActive(false);
//        gameObject.SetActive(false);
//        Cursor.lockState = CursorLockMode.Locked;
//        Achievements achievement = FindObjectOfType<Achievements>();

//        if (GlobalCs.arrIsGotAch[4]){
//            ActivateTeleport teleport = FindObjectOfType<ActivateTeleport>();
//            teleport.ActivaTeteleport();
//        }
//    }
//    private void OnTriggerExit(Collider other)
//    {
//        if (other.tag == "Player")
//        {
//            enter = false;
//            rezult.SetActive(false);
//        }
//    }
}
