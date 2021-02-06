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
            OnTeamChanged.Invoke();
        }
    }

    public UnityEvent onInfoChanged = new UnityEvent();
    public UnityEvent OnTeamChanged = new UnityEvent();

    private int size;
    public int Size => size;

    private int freeShipAmount = 0;
    public int FreeShipAmount => freeShipAmount;

    private int shipCount = 0;
    public int ShipCount => shipCount;

    /// <summary>
    /// Изменеяет количество кораблей планеты
    /// </summary>
    /// <param name="count"></param>
    public void ChangeShipCount(int count)
    {
        shipCount += count;

        //Если корабль сделал меньше 0. те при  1 юните на планете принес 2 юнита, стало -1. то при этом становится уже 1 юнит тимы корабля на планете
        if(shipCount < 0)
        {
            shipCount = Mathf.Abs(shipCount);
        }

        if(count > 0)
        {
            freeShipAmount += count;
        }
        onInfoChanged.Invoke();
    }

    /// <summary>
    /// Изменеяет количество кораблей планеты
    /// </summary>
    /// <param name="count"></param>
    public void ChangeFreeShipAmount(int count)
    {
        freeShipAmount += count;        
    }

    /// <summary>
    /// Установить размер
    /// </summary>
    /// <param name="newSize"></param>
    public void SetSize(int newSize)
    {
        size = newSize;
        onInfoChanged.Invoke();
    }
   
}
