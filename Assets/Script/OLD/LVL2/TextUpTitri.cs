using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TextUpTitri : MonoBehaviour
{
    public AudioClip audio, din;
    AudioSource Audio_Source;
    public GameObject Titri;
    private Text but;
    private Color old;
    public Color neww;
    public static int  speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        Audio_Source = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<AudioSource>();
      
        StartCoroutine(playAudio());
    }

    // Update is called once per frame
    void Update()
    {
        
        Titri.transform.position = new Vector3(transform.position.x, 20 + Time.fixedTime * 25, transform.position.z);
    }

    IEnumerator playAudio()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(audio.length);
        SceneManager.LoadScene("SampleScene");
        Debug.Log("END END EDN");
    }

    public void Return()
    {
        SceneManager.LoadScene("SampleScene");
        Audio_Source.Stop();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
            but.color = neww;
            Audio_Source.PlayOneShot(din);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
            but.color = old;
    }
}
