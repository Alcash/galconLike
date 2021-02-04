﻿using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Контроллер корабля
/// </summary>
public class ShipController : MonoBehaviour
{
    private TeamInfo teamInfo;
    public TeamInfo TeamInfo => teamInfo;

    private PlanetController targetPlanet;
    private NavMeshAgent agent;

    private bool isNearDistPlanet = false;

    private int shipPower = 1;
    public int ShipPower => shipPower;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        isNearDistPlanet = (transform.position - targetPlanet.transform.position).magnitude < targetPlanet.PlanetInfo.Size;

        if(isNearDistPlanet)
        {
            ArriveToPlanet();
        }        
    }

    private void ArriveToPlanet()
    {
        targetPlanet.TakeShip(this);
        ShipPool.Instance.ReturnToPool(this);
    }

    /// <summary>
    /// Установить цель
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(PlanetController planet)
    {
        targetPlanet = planet;
    }

    internal void SetTeam(TeamInfo newTeamInfo)
    {
        teamInfo = newTeamInfo;
    }
}
