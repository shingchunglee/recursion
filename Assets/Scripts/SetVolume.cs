using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolumeLevel(int level)
    {
        PlayerPrefs.SetInt("MusicVolume", level);
        float vol = level / 9f;
        audioMixer.SetFloat("MusicVol", (1 - Mathf.Sqrt(vol)) * -80f);
    }

    public void IncrementVolumeLevel()
    {
        int playerPrefVolume = PlayerPrefs.GetInt("MusicVolume", 9);
        if (playerPrefVolume < 9)
        {
            playerPrefVolume++;
            SetVolumeLevel(playerPrefVolume);
        }
    }

    public void DecrementVolumeLevel()
    {
        int playerPrefVolume = PlayerPrefs.GetInt("MusicVolume", 9);
        if (playerPrefVolume > 0)
        {
            playerPrefVolume--;
            SetVolumeLevel(playerPrefVolume);
        }
    }
}
