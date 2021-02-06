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
    public PlanetGenShipParam Bot => player;

    /// <summary>
    /// Установить значение на основе
    /// </summary>
    /// <param name="difficultSetting"></param>
    public void SetSettingPlanet(DifficultSetting difficultSetting)
    {
        minPlanetCount = difficultSetting.MinPlanetCount;
        maxPlanetCount = difficultSetting.MaxPlanetCount;
        Debug.Log("difficultSetting" + difficultSetting.name);
        Debug.Log("GenerateShip.Bot" + difficultSetting.Bot.GenerateShip);

        player.GenerateShip = difficultSetting.Player.GenerateShip;
        player.GenerateShipTime = difficultSetting.Player.GenerateShipTime;

        neutral.GenerateShip = difficultSetting.Neutral.GenerateShip;
        neutral.GenerateShipTime = difficultSetting.Neutral.GenerateShipTime;

        bot.GenerateShip = difficultSetting.Bot.GenerateShip;
        bot.GenerateShipTime = difficultSetting.Bot.GenerateShipTime;

        Debug.Log("GenerateShip.Bot" + bot.GenerateShip);
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
