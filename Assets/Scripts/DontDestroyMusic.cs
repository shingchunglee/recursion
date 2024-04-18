using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private GameObject musicPlayer;
    public AudioClip SoundClip;
    void Awake()
    {
        //When the scene loads it checks if there is an object called "MUSIC".
        musicPlayer = GameObject.FindWithTag("Music");
        if (musicPlayer == null)
        {
            musicPlayer = gameObject;
            musicPlayer.tag = "Music";
            DontDestroyOnLoad(musicPlayer);
            AudioSource soundSource = gameObject.AddComponent<AudioSource>();
            soundSource.loop = true;
            soundSource.clip = SoundClip;
            soundSource.Play();
        }
    }
}
