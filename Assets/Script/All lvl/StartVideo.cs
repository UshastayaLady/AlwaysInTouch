using UnityEngine;
using UnityEngine.Video;
public class StartVideo : MonoBehaviour
{
    [SerializeField] private GameObject nextquest;
    [SerializeField] private GameObject buttonSkip;
    private bool skip = false;
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
        if (Input.GetKeyDown(KeyCode.Space) && !skip)
        {            
            videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
            skip = true;
        }
    }
    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        Room_KID.enter = false;
        if(nextquest!=null)
            nextquest.SetActive(true);
        buttonSkip.SetActive(false);
        gameObject.SetActive(false);
    }

    private void play()
    {
        videoPlayer.Play();
    }

   
}



