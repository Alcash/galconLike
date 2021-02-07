using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер управления игрока
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private TeamInfo playerTeam;

    public TeamInfo PlayerTeam => playerTeam;

    private Camera cameraPlayer;

    private float rayDistance;

    private List<PlanetController> selectedPlanets = new List<PlanetController>();

    private void Awake()
    {
        cameraPlayer = Camera.main;
        rayDistance = cameraPlayer.farClipPlane;

        playerTeam = new TeamInfo(playerTeam.TeamName, playerTeam.TeamColor, Instantiate(playerTeam.MaterialTeam));
    }

    private void Update()
    {       

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hitInfo, rayDistance))
            {
                PlanetController planetHit =  hitInfo.collider.GetComponent<PlanetController>();

                if(planetHit != null)
                {
                    Interact(planetHit);
                }
            }
               
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance))
            {
                PlanetController planetHit = hitInfo.collider.GetComponent<PlanetController>();

                if (planetHit != null)
                {
                    SendShip(planetHit);
                }
            }

        }
    }

    private void Interact(PlanetController planetController)
    {
        if(planetController.PlanetInfo.TeamInfo == PlayerTeam)
        {
            ManageSelectedPlanets(planetController);
        }
        else
        {
            SendShip(planetController);

        }

       
    }

    private void ManageSelectedPlanets(PlanetController planetController)
    {
        SelectedPlanetView select = planetController.GetComponent<SelectedPlanetView>();

        if (selectedPlanets.Contains(planetController))
        {
            selectedPlanets.Remove(planetController);
            select.SelectPlanet(false);
        }
        else
        {
            selectedPlanets.Add(planetController);
            select.SelectPlanet(true);
        }

    }

    private void SendShip(PlanetController planetController)
    {
        foreach (var item in selectedPlanets)
        {
            item.SendShips(planetController);
        }
    }
}
