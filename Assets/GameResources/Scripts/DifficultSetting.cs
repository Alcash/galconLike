using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Настройки сложности
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "Setting/DifficultSetting", order = 1)]
public class DifficultSetting : ScriptableObject
{
    [SerializeField]
    private int minPlanetCount = 3;
    public int MinPlanetCount => minPlanetCount;
    [SerializeField]
    private int maxPlanetCount = 10;
    public int MaxPlanetCount => maxPlanetCount;
    [SerializeField]
    private int generateShipNeutral = 1;
    public int GenerateShipNeutral => generateShipNeutral;
    [SerializeField]
    private int generateShipNeutralTime = 5;
    public int GenerateShipNeutralTime => generateShipNeutralTime;
    [SerializeField]
    private int generateShipPlayer = 1;
    public int GenerateShipPlayer => generateShipPlayer;
    [SerializeField]
    private int generateShipPlayerTime = 5;
    public int GenerateShipPlayerTime => generateShipPlayerTime;

    /// <summary>
    /// Установить значение на основе
    /// </summary>
    /// <param name="difficultSetting"></param>
    public void SetSettingPlanet(DifficultSetting difficultSetting)
    {
        minPlanetCount = difficultSetting.MinPlanetCount;
        maxPlanetCount = difficultSetting.MaxPlanetCount;
        generateShipNeutral = difficultSetting.GenerateShipNeutral;
        generateShipNeutralTime = difficultSetting.GenerateShipNeutralTime;
        generateShipPlayer = difficultSetting.GenerateShipPlayer;
        generateShipPlayerTime = difficultSetting.GenerateShipPlayerTime;
    }
}
