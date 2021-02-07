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

    [SerializeField]
    private Material materialTeam;   
    public Material MaterialTeam => materialTeam;

    public TeamInfo()
    {
        teamName = "Neutral";
        teamColor = Color.gray;
    }

    public TeamInfo(string teamName, Color teamColor, Material material)
    {
        this.teamName = teamName;
        this.teamColor = teamColor;        
        materialTeam = material;
        materialTeam.name += "_" + teamName;
        materialTeam.color = teamColor;
    }

    public TeamInfo(TeamInfo teamInfo)
    {
        this.teamName = teamInfo.teamName;
        this.teamColor = teamInfo.teamColor;
        materialTeam = teamInfo.MaterialTeam;
        materialTeam.color = teamInfo.teamColor;
    }

}
