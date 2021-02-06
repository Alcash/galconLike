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

    private BotController botController;

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
        bool oneTeam = true;
        TeamInfo teamInfo = worldGenerator.PlanetControllers.FirstOrDefault().PlanetInfo.TeamInfo;
       
        foreach (var item in worldGenerator.PlanetControllers)
        {          
            oneTeam &= teamInfo == item.PlanetInfo.TeamInfo;            
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
