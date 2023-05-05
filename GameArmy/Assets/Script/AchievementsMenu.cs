using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static GlobalCs;

public class AchievementsMenu : MonoBehaviour
{
    public GameObject[] achievement_image_disabled = new GameObject[GlobalCs.arrIsGotAch.Length];
    public GameObject[] achievement_image_enabled = new GameObject[GlobalCs.arrIsGotAch.Length];


    // Start is called before the first frame update
    void OnEnable()
    {
        GlobalCs.print();
        for (int i = 0; i < GlobalCs.arrIsGotAch.Length; i++)
        {
            if (!GlobalCs.arrIsGotAch[i]) continue;
            achievement_image_disabled[i].SetActive(false);
            achievement_image_enabled[i].SetActive(true);
        }
        
    }

}
