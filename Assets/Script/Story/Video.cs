using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Drag your Video Player here in inspector
    public Button myButton; // Drag your Button here in inspector

    void Start()
    {
        myButton.gameObject.SetActive(false); // Hide the button at the start
        videoPlayer.loopPointReached += OnVideoEnded; // Subscribe to the loopPointReached event
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        myButton.gameObject.SetActive(true); // Show the button when video ends
    }
}
