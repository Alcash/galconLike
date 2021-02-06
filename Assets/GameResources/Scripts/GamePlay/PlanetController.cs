using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер планеты
/// </summary>
public class PlanetController : MonoBehaviour
{    
    private float percentShipSend = 0.5f;
    private PlanetInfo planetInfo;
    public PlanetInfo PlanetInfo => planetInfo;

    private int armadaParamter = 50;

    private int wave = 0;

    private void Awake()
    {
        planetInfo = GetComponent<PlanetInfo>();
    }

    /// <summary>
    /// Отправить корабли
    /// </summary>
    /// <param name="anotherPlanetController"></param>
    public void SendShips(PlanetController anotherPlanetController)
    {
        int sendCount = (int)(planetInfo.FreeShipAmount * percentShipSend);
    
        planetInfo.ChangeFreeShipAmount(-sendCount);

        StartCoroutine(SendingShips(sendCount, anotherPlanetController, wave));
        wave++;
    }

    private IEnumerator SendingShips(int count, PlanetController anotherPlanetController, int curWave)
    {
        int shipSize = (int)((float)count) / armadaParamter + 1;
        int currentShipSize = 1;
        
        for (int i = count; i > 0; )
        {           
            ShipController ship = ShipPool.Instance.GetObject();

            Vector3 toPlanet = (anotherPlanetController.transform.position - transform.position).normalized;

            toPlanet *= PlanetInfo.Size/2;
            ship.transform.position = transform.position + toPlanet;

            currentShipSize = Mathf.Min(shipSize, i);
            i -= currentShipSize;

            ship.SetShipPower(shipSize);
            ship.SetTeam(planetInfo.TeamInfo);
            ship.gameObject.SetActive(true);

            ship.SetTarget(anotherPlanetController);           
            planetInfo.ChangeShipCount(-ship.ShipPower);
            yield return null;
        }
    }

    /// <summary>
    /// Получить корабли
    /// </summary>
    /// <param name="shipController"></param>
    public void TakeShip(ShipController shipController)
    {
        if (PlanetInfo.ShipCount <= 0)
        {
            ChangeTeam(shipController.TeamInfo);
        }

        if (planetInfo.TeamInfo == shipController.TeamInfo)
        {
            PlanetInfo.ChangeShipCount(shipController.ShipPower);
        }
        else
        {
            PlanetInfo.ChangeShipCount(-shipController.ShipPower);
        }       
    }    

    /// <summary>
    /// Изменяет команду планеты
    /// </summary>
    /// <param name="teamInfo"></param>
    public void ChangeTeam(TeamInfo teamInfo)
    {        
        planetInfo.TeamInfo = teamInfo;
    }
}

