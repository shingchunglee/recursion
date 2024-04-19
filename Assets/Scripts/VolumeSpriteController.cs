using System;
using System.Collections;
using UnityEngine;

public class VolumeSpriteController : MonoBehaviour
{
    ButtonSpriteController buttonSpriteController;
    [SerializeField] VolumeSprites[] sprites;
    private void Start()
    {
        buttonSpriteController = GetComponent<ButtonSpriteController>();
        UpdateFromPlayerPrefs();
    }

    public void UpdateFromPlayerPrefs()
    {
        StartCoroutine(DelayUpdateFromPlayerPrefs());
    }

    IEnumerator DelayUpdateFromPlayerPrefs()
    {
        yield return 0;
        int playerPrefVolume = PlayerPrefs.GetInt("MusicVolume", 9);
        UpdateVolumeSprite(playerPrefVolume);
    }

    public void UpdateVolumeSprite(int volume)
    {
        GetComponent<SpriteRenderer>().sprite = GetSprite(volume)[0];
        buttonSpriteController.ReleaseSprite = GetSprite(volume)[0];
        buttonSpriteController.PressedSprite = GetSprite(volume)[1];
    }

    private Sprite[] GetSprite(int volume)
    {
        return Array.Find(sprites, s => s.volume == volume).sprites;
    }

    [Serializable]
    struct VolumeSprites
    {
        public Sprite[] sprites;
        public int volume;
    }
}

