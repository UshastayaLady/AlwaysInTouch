using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCs : MonoBehaviour
{
    private static int numOfAch = 5;
    public static bool[] arrIsGotAch = new bool[numOfAch];

    public static void print()
    {
        foreach (var item in arrIsGotAch) 
        {
            Debug.Log(item.ToString());
        }
    }


}
