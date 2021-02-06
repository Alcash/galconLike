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

    [SerializeField]
    private DifficultSetting difficultSetting;

    private void Awake()
    {
        planetInfo = GetComponent<PlanetInfo>();
        planetInfo.OnTeamChanged.AddListener(UpdateGenerateShip);
        UpdateGenerateShip();
    }

    private void OnDestroy()
    {
        planetInfo.OnTeamChanged.RemoveListener(UpdateGenerateShip);
    }

    private void UpdateGenerateShip()
    {       
        //TODO: Ограничение для нейтралов. если не придумаю лучше
        if (planetInfo.TeamInfo.TeamName == "Neutral")
        {
            SetParam (difficultSetting.Neutral);
          
        }
        else if(planetInfo.TeamInfo.TeamName == "Player")
        {
            SetParam(difficultSetting.Player);
           
        }
        else
        {
            SetParam(difficultSetting.Bot);
        }        
    }

    private void SetParam(PlanetGenShipParam param)
    {
        shipPerPeriod = param.GenerateShip;
        timerPeriod = param.GenerateShipTime;
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
