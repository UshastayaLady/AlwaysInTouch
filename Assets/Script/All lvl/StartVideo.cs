using UnityEngine;
using UnityEngine.Video;
public class StartVideo : MonoBehaviour
{
    [SerializeField] private GameObject CloseObject;
    [SerializeField] private GameObject nextquest;
    [SerializeField] private GameObject buttonSkip;
    VideoPlayer videoPlayer;
     
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();

        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
        videoPlayer.Play();
        Invoke("Skip", 2);
    }
    
    private void Update()
    {
        if (buttonSkip.activeSelf && videoPlayer.isPlaying && (Input.anyKeyDown))
        {
            videoPlayer.Stop();
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

    private void Skip()
    {
        buttonSkip.SetActive(true);
    }
}



