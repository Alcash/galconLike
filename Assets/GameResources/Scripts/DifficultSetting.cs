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
    private PlanetGenShipParam neutral;
    public PlanetGenShipParam Neutral => neutral;

    [SerializeField]
    private PlanetGenShipParam player;
    public PlanetGenShipParam Player => player;

    [SerializeField]
    private PlanetGenShipParam bot;
    public PlanetGenShipParam Bot => bot;

    /// <summary>
    /// Установить значение на основе
    /// </summary>
    /// <param name="difficultSetting"></param>
    public void SetSettingPlanet(DifficultSetting difficultSetting)
    {
        minPlanetCount = difficultSetting.MinPlanetCount;
        maxPlanetCount = difficultSetting.MaxPlanetCount;     
        
        player = difficultSetting.Player;
        neutral = difficultSetting.Neutral;
        bot = difficultSetting.Bot;
    }

    private void SctructSet(PlanetGenShipParam param, PlanetGenShipParam newParam)
    {
        param.GenerateShip = newParam.GenerateShip;
        param.GenerateShipTime = newParam.GenerateShipTime;
    }
}

[System.Serializable]
public class PlanetGenShipParam
{   
    public int GenerateShip;
    public int GenerateShipTime;
}
