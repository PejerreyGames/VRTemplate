using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Transform initialPosition;
    public GameObject player;
    public bool waitTime;
    
    private void Update()
    {
        if (videoPlayer.time >= videoPlayer.clip.length-1)
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        player.transform.position = initialPosition.position;
        videoPlayer.Stop();
        videoPlayer.Pause();
        SceneController.Instance.ChangeSceneAsync("MainScene");
    }
}
