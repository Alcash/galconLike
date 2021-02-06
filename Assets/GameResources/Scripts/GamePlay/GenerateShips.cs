using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Генерация кораблей
/// </summary>
public class GenerateShips : MonoBehaviour
{    
    private PlanetInfo planetInfo;
    [SerializeField]
    private int shipPerPeriod = 5;

    private float timerPeriod = 1;

    private float timer;

    private void Awake()
    {
        planetInfo = GetComponent<PlanetInfo>();
        planetInfo.onInfoChanged.AddListener(UpdateGenerateShip);        
    }

    private void OnDestroy()
    {
        planetInfo.onInfoChanged.RemoveListener(UpdateGenerateShip);
    }

    private void UpdateGenerateShip()
    {
        //TODO: Ограничение для нейтралов. если не придумаю лучше
        if (planetInfo.TeamInfo.TeamName == "Neutral")
        {
            shipPerPeriod = 1;
            timerPeriod = 5;
        }
    }

    private void Update()
    {
        if (planetInfo != null)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = timerPeriod;
                planetInfo.ChangeShipCount(shipPerPeriod);
            }
        }
    }    
}
