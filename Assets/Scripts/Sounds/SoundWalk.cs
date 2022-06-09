using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWalk : MonoBehaviour
{
    public static AudioSource audioSrcWalk;
    public static AudioClip RunningSound;

    void Start()
    {
        RunningSound = Resources.Load<AudioClip>("running");
        audioSrcWalk = GetComponent<AudioSource>();
    }

    public static void PlayWalk(string clip)
    {
        if (clip == "running")
        {
            audioSrcWalk.PlayOneShot(RunningSound, 0.75F);

        }
        else if (clip == "stop")
        {
            audioSrcWalk.Stop();
        }
    }
}
