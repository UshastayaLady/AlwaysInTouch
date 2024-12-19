using UnityEngine;
using UnityEngine.UI;

public class PlaneBlack : MonoBehaviour
{
    //private CursorManager cursorManager;
    public GameObject Object,AlphaObj;
    Image AlphaImage;
    public float AlphaA;
    bool PressStart;
    // Start is called before the first frame update
    void Start()
    {
        AlphaImage = AlphaObj.GetComponent<Image>();
        AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a );
    }

    // Update is called once per frame
    void Update()
    {
        if (PressStart && AlphaImage.color.a > 0)
        {
            AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a - 0.5f * Time.deltaTime);
            AlphaA = AlphaImage.color.a;
           // Debug.Log(AlphaA);
            if (AlphaImage.color.a < 0.1)
            {
                Object.SetActive(true);
            }
        

        }
    }

    public void Press()
    {
        Time.timeScale = 1f;
        GameObject script;
        script = GameObject.Find("MainCanvas");
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
        
    }

}
