using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

/// <summary>
/// Контроллер игры
/// </summary>
public class GameController : MonoBehaviour
{
    public static UnityAction OnPlanetChangeTeam = delegate { };
    [SerializeField]
    private WorldGenerator worldGenerator;

    [SerializeField]
    private GameObject mainMenu;

    private float waitToEndTime = 2;

    [SerializeField]
    private ShipPool shipPool;

    /// <summary>
    /// Начать игру
    /// </summary>
    public void StartGame()
    {        
        worldGenerator.GenerateWorld();
        mainMenu.SetActive(false);
        OnPlanetChangeTeam += CheckEndGame;

    }

    /// <summary>
    /// Закончить игру
    /// </summary>
    public void EndGame()
    {
        worldGenerator.ClearWorld();
        mainMenu.SetActive(true);
        OnPlanetChangeTeam -= CheckEndGame;
        shipPool.HideShips();
    }


    private void CheckEndGame()
    {
        Debug.Log("CheckEndGame");

        bool oneTeam = true;
        TeamInfo teamInfo = worldGenerator.PlanetControllers.FirstOrDefault().PlanetInfo.TeamInfo;
        Debug.Log("teamInfo " + teamInfo.TeamName);
        foreach (var item in worldGenerator.PlanetControllers)
        {
            Debug.Log("item " + item.PlanetInfo.TeamInfo.TeamName);
            oneTeam &= teamInfo == item.PlanetInfo.TeamInfo;
            Debug.Log("oneTeam " + oneTeam);
        }

        if(oneTeam)
        {
            StartCoroutine(WaitToEndGame());
        }
    }

    private IEnumerator WaitToEndGame()
    {
        yield return new WaitForSeconds(waitToEndTime);
        EndGame();
    }
}
