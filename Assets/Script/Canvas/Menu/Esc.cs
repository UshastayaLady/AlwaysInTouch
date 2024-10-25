using UnityEngine;

public class Esc : MonoBehaviour
{
    private bool klavisha;
    public GameObject menuCanv;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            klavisha = !klavisha;

            
            if (klavisha)
            {
                menuCanv.SetActive(true);
                Time.timeScale = 0f;
            }

            else if (!klavisha)
            {
                menuCanv.SetActive(false);
                CursorManager.instance.cursorWork = false;
                Time.timeScale = 1f;
            }
        }

    }

    public void Cont()
    {
        menuCanv.SetActive(false);
        Time.timeScale = 1f;
        klavisha = !klavisha;
    }

public void ExitBt()
    {
        Application.Quit();
    }
}
