using UnityEngine;

public class VIdeo_end : MonoBehaviour
{
    public GameObject[] video_mass;
    public GameObject Button_sceap;
    
   public static int i = 0;
    
    public void OnClickButton()
    {
        if (i == video_mass.Length - 1)
        {
            video_mass[i].SetActive(false);
            Button_sceap.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            i++;
        }

        else
        {
            video_mass[i + 1].SetActive(true);
            video_mass[i].SetActive(false);
            i++;            
        }

    }
}
