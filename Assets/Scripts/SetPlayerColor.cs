using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Events;

public class SetPlayerColor : MonoBehaviour
{
    public UnityEvent<int> UpdateColors;

    private void Start()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            var playerColorController = player.GetComponent<PlayerColorController>();
            UpdateColors.AddListener((int val) => playerColorController.SetPlayerColor((PlayerColor)val));
        }
    }

    public void SetPlayerPrefColor(int color)
    {
        PlayerPrefs.SetInt("PlayerColor", color);
        UpdateColors.Invoke(color);
    }

    public void IncrementPlayerColor()
    {
        int playerPrefColor = PlayerPrefs.GetInt("PlayerColor", 0);
        playerPrefColor = (playerPrefColor + 1) % Enum.GetNames(typeof(PlayerColor)).Length;
        Debug.Log(playerPrefColor);
        SetPlayerPrefColor(playerPrefColor);
    }

    public void DecrementPlayerColor()
    {
        int playerPrefColor = PlayerPrefs.GetInt("PlayerColor", 0);
        playerPrefColor = (playerPrefColor - 1 + Enum.GetNames(typeof(PlayerColor)).Length) % Enum.GetNames(typeof(PlayerColor)).Length;
        Debug.Log(playerPrefColor);
        SetPlayerPrefColor(playerPrefColor);
    }
}
