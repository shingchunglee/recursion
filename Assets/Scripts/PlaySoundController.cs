using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundController : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayClipOnce(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
