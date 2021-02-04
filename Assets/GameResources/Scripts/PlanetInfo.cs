using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Информация о планете
/// </summary>
public class PlanetInfo : MonoBehaviour
{

    private TeamInfo teamInfo = new TeamInfo();

    public TeamInfo TeamInfo
    {
        get
        {
            return teamInfo;
        }

        set
        {
            teamInfo = value;
            onInfoChanged.Invoke();
        }
    }

    public UnityEvent onInfoChanged = new UnityEvent();

    private int size;
    public int Size => size;


    private int shipCount = 0;
    public int ShipCount => shipCount;

    /// <summary>
    /// Изменеяет количество кораблей планеты
    /// </summary>
    /// <param name="count"></param>
    public void ChangeShipCount(int count)
    {
        shipCount += count;
        onInfoChanged.Invoke();
    }  
    
    public void SetSize(int newSize)
    {
        size = newSize;
        onInfoChanged.Invoke();
    }
   
}
