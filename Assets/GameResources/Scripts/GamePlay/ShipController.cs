using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Контроллер корабля
/// </summary>
public class ShipController : MonoBehaviour
{
    private TeamInfo teamInfo = new TeamInfo();
    public TeamInfo TeamInfo => teamInfo;

    private PlanetController targetPlanet;
    private NavMeshAgent agent;

    private bool isNearDistPlanet = false;

    private int shipPower = 1;
    public int ShipPower => shipPower;

    private float distanceToPlanetOffsetMulti = 0.6f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (targetPlanet != null)
        {
            isNearDistPlanet = (transform.position - targetPlanet.transform.position).magnitude < targetPlanet.PlanetInfo.Size * distanceToPlanetOffsetMulti;
        }

        if(isNearDistPlanet)
        {
            ArriveToPlanet();
        }        
    }

    private void ArriveToPlanet()
    {
        targetPlanet.TakeShip(this);
        ShipPool.Instance.ReturnToPool(this);
    }

    /// <summary>
    /// Установить цель
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(PlanetController planet)
    {
        targetPlanet = planet;
        agent.SetDestination(targetPlanet.transform.position);
    }

    /// <summary>
    /// Установить команду
    /// </summary>
    /// <param name="newTeamInfo"></param>
    public void SetTeam(TeamInfo newTeamInfo)
    {
        teamInfo = newTeamInfo;
    }
}
