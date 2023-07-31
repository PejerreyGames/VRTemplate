using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    
    public List<videomp4> videos;
    
    private int currentVideoIndex = 0;
    private VideoPlayer videop;

    private void Start()
    {
        videop = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwitchToNextVideo();
        }
    }
    
    private void SwitchToNextVideo()
    {
        currentVideoIndex = (currentVideoIndex + 1) % videos.Count;
        PlayCurrentVideo();
    }
    
    private void PlayCurrentVideo()
    {
        if (videos.Count > 0)
        {
            videop.clip = videos[currentVideoIndex].GetVideoClip();
            videop.Play();
        }
    }
}
