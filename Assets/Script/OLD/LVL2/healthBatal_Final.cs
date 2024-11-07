using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthBatal_Final : MonoBehaviour
{
    public GameObject trigg;
    public static int proideno;
    public int shetchik;
    public int pravilno;
    public int Vibor_testa;
    public static bool Global_enter;
    public GameObject Trigg_end;
    public GameObject Test;
    public GameObject Testing;
    public Text Text_zvanie;
    public Text Text_ball;



    private void Start()
    {
        Test.SetActive(false);
        Global_enter = false;
        Trigg_end.SetActive(false);
        
    }
    private void Update()
    {
        if (Testing.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }       
    }
    public void shcet()
    {
        shetchik++;
    }

    public void Pravilno()
    {
        pravilno++;
    }

    public void Test1()
    {
        Vibor_testa = 1;
    }





    public void Reshenie()
    {
        Destroy(trigg);      
        Global_enter = true;
        Trigg_end.SetActive(true);

    }

    public void Titri()
    {
        SceneManager.LoadScene("Titri");
    }

    
}
