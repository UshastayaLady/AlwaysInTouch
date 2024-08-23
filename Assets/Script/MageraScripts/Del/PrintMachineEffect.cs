using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintMachineEffect : MonoBehaviour
{
    public static PrintMachineEffect instance = null;
    public void Start()
    {
        if (instance == null)
        { instance = this; }    

    }

    public IEnumerator printMachineEffect(Text texyUI, string text, Button IntorButton)
    {
        IntorButton.enabled = false;
        float time = 0.001f;
        for (int i = 0; i < text.Length; i++)
        {
            time = 0.01f;
            texyUI.text += text[i];

            if(text[i] == '.')
                time = 0.5f;
            if (text[i] == ',')
                time = 0.05f;

            yield return new WaitForSeconds(time);
        }
        IntorButton.enabled = true;
    }
}
