using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip FireSound;
    public static AudioClip JumpSound;
    public static AudioClip NothingSound;
    public static AudioClip GrapplingSound;
    public static AudioClip BackSound;
    public static AudioClip ReloadSound;
    public static AudioClip ScreamSound;
    public static AudioSource audioSrc;

    void Start()
    {
        FireSound = Resources.Load<AudioClip>("gunshot");
        JumpSound = Resources.Load<AudioClip>("jump");
        NothingSound = Resources.Load<AudioClip>("nothing");
        GrapplingSound = Resources.Load<AudioClip>("grappling");
        BackSound = Resources.Load<AudioClip>("backintime");
        ReloadSound = Resources.Load<AudioClip>("reload");
        ScreamSound = Resources.Load<AudioClip>("Scream");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "stop":
                audioSrc.Stop();
                break;
            case "reload":
                audioSrc.PlayOneShot(ReloadSound, 1F);
                break;
            case "gunshot":
                audioSrc.PlayOneShot(FireSound, 0.5F);
                break;
            case "jump":
                audioSrc.PlayOneShot(JumpSound, 1F);
                break;
            case "grappling":
                audioSrc.PlayOneShot(GrapplingSound, 0.75F);
                break;
            case "backintime":
                audioSrc.PlayOneShot(BackSound, 1F);
                break;
            case "scream":
                audioSrc.PlayOneShot(ScreamSound, 1f);
                break;
            default:
                audioSrc.PlayOneShot(NothingSound);
                break;

        }
    }
}
