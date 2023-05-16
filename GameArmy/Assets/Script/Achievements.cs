using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalCs;

public class Achievements : MonoBehaviour
{
    public GameObject achievement_image;
    public GameObject achievemnt_text;
    private Coroutine hideCoroutine;

    public void showAchieve(string achievement_name, int num){
        GlobalCs.arrIsGotAch[num] = true;
        achievement_image.SetActive(true);
        achievemnt_text.GetComponent<Text>().text = achievement_name;
        

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(HideAchievement(achievement_image));

        
    }



    IEnumerator HideAchievement(GameObject achievement_image)
    {
        yield return new WaitForSeconds(5f);
        achievement_image.SetActive(false);
    }
}
