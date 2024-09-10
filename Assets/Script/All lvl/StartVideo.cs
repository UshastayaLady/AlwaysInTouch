using UnityEngine;
using UnityEngine.Video;
public class StartVideo : MonoBehaviour
{
    [SerializeField] private GameObject nextquest;
    [SerializeField] private GameObject buttonSkip;
    VideoPlayer videoPlayer;
     
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();

        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;

        Invoke("play", 1);
        buttonSkip.SetActive(true);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonSkip.SetActive(false);
            videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
        }
    }
    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        Room_KID.enter = false;
        if(nextquest!=null)
            nextquest.SetActive(true);
        gameObject.SetActive(false);
    }

    private void play()
    {
        videoPlayer.Play();
        buttonSkip.SetActive(false);
    }

   
}



