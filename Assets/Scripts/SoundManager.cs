using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip perfect, nice, wellplayed, tryagain;
    static AudioSource audioSrc;

    void Start()
    {
        perfect = Resources.Load<AudioClip>("perfect");
        nice = Resources.Load<AudioClip>("nice");
        wellplayed = Resources.Load<AudioClip>("wellplayed");
        tryagain = Resources.Load<AudioClip>("tryagain");
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "perfect":
                audioSrc.PlayOneShot(perfect);
                break;
            case "nice":
                audioSrc.PlayOneShot(nice);
                break;
            case "wellplayed":
                audioSrc.PlayOneShot(wellplayed);
                break;
            case "tryagain":
                audioSrc.PlayOneShot(tryagain);
                break;
        }
    }
}
