using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General_Test : MonoBehaviour
{
    public GameObject[] ButtonTest;
    GameObject SelectButton;
    int good;
    
    public void PutOn(GameObject button)
    {
         for (int i = 0; i < ButtonTest.Length; i++)
        {
            
            if (button == ButtonTest[i] && button.tag == "TestButton")
            {
                SelectButton = button;
                //Debug.Log(SelectButton.transform.parent);
            }
            
        }
    } 

    public void Good()
    {
        good++;
        Debug.Log(good);
    }

    public void Final()
    {
        if(good == 5)
        {
            Debug.Log("The BEST !!!");
            SelectButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.green;
            SelectButton.GetComponent<Button>().enabled = false;
        }
        good = 0;
    }


}
