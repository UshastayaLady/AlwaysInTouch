using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenTarget : MonoBehaviour
{
    public int scores = 0;
    public int scr = 0;
  
    public int oldscore = 0;
    public List<int> scoresList;

    public Transform center;
    public Transform edge;

    public Text scoresText;
    public Text scoresText_eng;


    public static bool flag;
    private float totalLength;
    private float sectionLength;
    public  int six;
    public  int sev;
    public  int vos;
    public  int nine;
    public  int ten;

    private void Start()
    {
        totalLength = (edge.position - center.position).magnitude;
        sectionLength = totalLength / scoresList.Count;
        six = 0;
        sev = 0;
        vos = 0;
        nine = 0;
        ten = 0;
        scr = 0;
        scoresText.text = string.Format("Очки: {0}", scr);
    }
   
    public void CalculateScores(Vector3 hitPosition)
    {
        var dist = (hitPosition - center.position).magnitude;

        if (dist < totalLength)
        {
            scores += scoresList[(int)(dist / sectionLength)];
            
        }
            scr = scores;
            scoresText.text = string.Format("Очки: {0}", scores);

        if (scores - oldscore == 6)
            {
                six++;
                oldscore = scores;
            }
            if (scores - oldscore == 7)
            {
                sev++;
                oldscore = scores;
        }
            if (scores - oldscore == 8)
            {
                vos++;
            oldscore = scores;
        }
            if (scores - oldscore == 9)
            {
                nine++;
            oldscore = scores;
        }
            if (scores - oldscore == 10)
            {
                ten++;
            oldscore = scores;
        }
    }
}
