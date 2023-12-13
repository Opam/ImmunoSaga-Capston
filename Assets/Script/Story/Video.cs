using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button myButton; 

    void Start()
    {
        myButton.gameObject.SetActive(false); 
        videoPlayer.loopPointReached += OnVideoEnded; 
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        myButton.gameObject.SetActive(true);
    }
}
