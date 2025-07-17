using UnityEngine;

public class Esc : MonoBehaviour
{
    private bool klavisha;
    [SerializeField] private GameObject menuCanv;
    [SerializeField] private GameObject musicGame;
    [SerializeField] private GameObject [] atherCanvas;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            klavisha = !klavisha;

            
            if (klavisha)
            {
                for (int i = 0; i < atherCanvas.Length; i++)
                {
                    atherCanvas[i].GetComponent<Canvas>().enabled = false;
                }
                musicGame.SetActive(false);
                menuCanv.SetActive(true);
                
                Time.timeScale = 0f;
            }

            else if (!klavisha)
            {
                menuCanv.SetActive(false);
                for (int i = 0; i < atherCanvas.Length; i++)
                {
                    atherCanvas[i].GetComponent<Canvas>().enabled = true;
                }
                musicGame.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }

    public void Cont()
    {
        menuCanv.SetActive(false);
        for (int i = 0; i < atherCanvas.Length; i++)
        {
            atherCanvas[i].GetComponent<Canvas>().enabled = true;
        }
        Time.timeScale = 1f;
        klavisha = !klavisha;
    }

public void ExitBt()
    {
        Application.Quit();
    }
}
