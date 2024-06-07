using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Events;

public class SetGoalColor : MonoBehaviour
{
    public UnityEvent<int> UpdateColors;

    private void Start()
    {
        var goals = GameObject.FindGameObjectsWithTag("Goal");
        foreach (var goal in goals)
        {
            var goalColorController = goal.GetComponent<GoalColorController>();
            UpdateColors.AddListener((int val) => goalColorController.SetColor((PlayerColor)val));
        }
    }

    public void SetPlayerPrefColor(int color)
    {
        PlayerPrefs.SetInt("GoalColor", color);
        UpdateColors.Invoke(color);
    }

    public void IncrementPlayerColor()
    {
        int goalPrefColor = PlayerPrefs.GetInt("GoalColor", 0);
        goalPrefColor = (goalPrefColor + 1) % Enum.GetNames(typeof(PlayerColor)).Length;
        Debug.Log(goalPrefColor);
        SetPlayerPrefColor(goalPrefColor);
    }

    public void DecrementPlayerColor()
    {
        int goalPrefColor = PlayerPrefs.GetInt("GoalColor", 0);
        goalPrefColor = (goalPrefColor - 1 + Enum.GetNames(typeof(PlayerColor)).Length) % Enum.GetNames(typeof(PlayerColor)).Length;
        Debug.Log(goalPrefColor);
        SetPlayerPrefColor(goalPrefColor);
    }
}
