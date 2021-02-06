using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Информация о команде
/// </summary>
[Serializable]
public class TeamInfo
{
    [SerializeField]
    private string teamName = "Player";
    public string TeamName => teamName;
    [SerializeField]
    private Color teamColor = Color.cyan;
    public Color TeamColor => teamColor;

    public TeamInfo()
    {
        teamName = "Neutral";
        teamColor = Color.gray;
    }

    public TeamInfo(string teamName, Color teamColor)
    {
        this.teamName = teamName;
        this.teamColor = teamColor;
    }
}
