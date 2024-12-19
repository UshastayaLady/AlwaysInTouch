using UnityEngine;
using UnityEngine.Video;
public class StartVideo : MonoBehaviour
{
    [SerializeField] private GameObject CloseObject;
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
    }
    private void OnEnable()
    {
        buttonSkip.SetActive(true);
        skip = false;
    }
    private void Update()
    {
        if (Input.anyKeyDown && !skip && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            skip = true;
            VideoPlayer_loopPointReached(videoPlayer);
        }
    }
    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        if(nextquest!=null)
            nextquest.SetActive(true);
        buttonSkip.SetActive(false);
        gameObject.SetActive(false);
        CloseObject.SetActive(false);
    }

    private void play()
    {
        videoPlayer.Play();
    }

   
}



