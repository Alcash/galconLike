using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Контроллер игры
/// </summary>
public class GameController : MonoBehaviour
{   
    [SerializeField]
    private GameObject planetPrefab;

    private int minPlanetCount = 3;
    private int maxPlanetCount = 10;
       
    private PlayerController playerController;

    private List<PlanetController> planetControllers = new List<PlanetController>();

    private int minPlanetSize = 3;
    private int maxPlanetSize = 7;


    private void OnEnable()
    {
        playerController = FindObjectOfType<PlayerController>();
        CreateWorld();    
    }

    private void CreateWorld()
    {

        int planetCount = Random.Range(minPlanetCount, maxPlanetCount);

        for(int i = 0; i< planetCount; i++)
        {
            Vector3 spawnPos = Random.insideUnitSphere  * planetCount * planetCount;
            spawnPos.y = transform.position.y;
            CreatePlanet(spawnPos);
        }

        int playerRandPlanet = Random.Range(0, planetCount);
        ChoosePlayerPlanet(planetControllers[playerRandPlanet]);
    }

    private void CreatePlanet(Vector3 vector3)
    {
        GameObject planetGO = Instantiate(planetPrefab, vector3,Quaternion.identity);
        PlanetController planetController = planetGO.GetComponent<PlanetController>();
        planetControllers.Add(planetController);
        int size = Random.Range(minPlanetSize, maxPlanetSize);

        planetController.PlanetInfo.SetSize(size);
    }

    private void ChoosePlayerPlanet(PlanetController planetController)
    {
        planetController.ChangeTeam(playerController.PlayerTeam);
    }
}
