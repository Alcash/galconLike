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
        int sendCount = (int)(planetInfo.ShipCount * percentShipSend);
        {
           StartCoroutine(SendingShips(sendCount, anotherPlanetController));
        }
    }

    private IEnumerator SendingShips(int count, PlanetController anotherPlanetController)
    {
        for (int i = 0; i < count; i++)
        {           
            ShipController ship = ShipPool.Instance.GetObject();
            ship.transform.position = transform.position;
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
        if (PlanetInfo.ShipCount == 0)
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
        Debug.Log("ChangeTeam");
        planetInfo.TeamInfo = teamInfo;
    }
}

