using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер бота простой
/// </summary>
public class BotController : MonoBehaviour
{
    
    private WorldGenerator world;
    [SerializeField]
    private DifficultSetting difficultSetting;

    private TeamInfo teamInfo;

    private List<PlanetController> planets= new List<PlanetController>();
       
    private void OnDestroy()
    {
        foreach (var item in world.PlanetControllers)
        {
            item.PlanetInfo.OnTeamChanged.RemoveListener(planetInfoChangedHandler);
        }
    }

    /// <summary>
    /// Инициализация бота
    /// </summary>
    /// <param name="teamInfo"></param>
    /// <param name="montherPlanet"></param>
    public void InitBot(TeamInfo _teamInfo, PlanetController montherPlanet, WorldGenerator world)
    {
        this.world = world;
        teamInfo = _teamInfo;  

        transform.position = montherPlanet.transform.position;

        foreach (var item in world.PlanetControllers)
        {
            item.PlanetInfo.OnTeamChanged.AddListener(planetInfoChangedHandler);
        }
        montherPlanet.ChangeTeam(teamInfo);
        StartCoroutine(PlayingBot());
    }

    private void planetInfoChangedHandler()
    {       
        foreach (var item in world.PlanetControllers)
        {
            Manager(item);
        }
    }   

    private void Manager(PlanetController planetController)
    {      
        if (planetController.PlanetInfo.TeamInfo != teamInfo)
        {            
            planets.Remove(planetController);
        }
        else if (planets.Contains(planetController) == false)
        {          
            planets.Add(planetController);
        }
    }   
    
    private IEnumerator PlayingBot()
    {

        while(planets.Count > 0 || planets.Count != world.PlanetControllers.Count)
        {
            yield return new WaitForSeconds(3);

            foreach (var item in planets)
            {
                item.SendShips(FindNear());
            }
        }
        yield return null;

        Destroy(gameObject);
    }

    private PlanetController FindNear()
    {
        PlanetController result = null;
        float minDistance = float.PositiveInfinity;
        foreach (var item in world.PlanetControllers)
        {
            if (item.PlanetInfo.TeamInfo != teamInfo && (item.transform.position - transform.position).magnitude < minDistance)
            {
                result = item;
                minDistance = (item.transform.position - transform.position).magnitude;
            }
        }

        return result;
    }
}
