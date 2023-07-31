using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[System.Serializable]
public class videomp4
{
    [SerializeField]
    private VideoClip video;
    [SerializeField]
    private long frame;

    public videomp4(VideoClip video, int frame)
    {
        this.video = video;
        this.frame = frame;
    }

    public VideoClip GetVideoClip()
    {
        return video;
    }

    public long GetFrame()
    {
        return frame;
    }

    public void SetFrame(int a)
    {
        frame = a;
    }
}
