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

    private int minPlanetCount = 2;
    private int maxPlanetCount = 10;
       
    private PlayerController playerController;

    private List<PlanetController> planetControllers = new List<PlanetController>();

     

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
        planetControllers.Add(planetGO.GetComponent<PlanetController>());        
    }

    private void ChoosePlayerPlanet(PlanetController planetController)
    {
        planetController.ChangeTeam(playerController.PlayerTeam);
    }
}
