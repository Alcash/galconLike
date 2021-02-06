using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Random = UnityEngine.Random;

/// <summary>
/// Контроллер игры
/// </summary>
public class WorldGenerator : MonoBehaviour
{   
    [SerializeField]
    private GameObject planetPrefab;
    [SerializeField]
    private int minPlanetCount = 3;
    [SerializeField]
    private int maxPlanetCount = 10;
       
    private PlayerController playerController;

    private List<PlanetController> planetControllers = new List<PlanetController>();

    [SerializeField]
    private int minPlanetSize = 6;
    [SerializeField]
    private int maxPlanetSize = 15;

    [SerializeField]
    private int worldHeight = 42*2;
    [SerializeField]
    private int worldWidth = 78*2;


    private bool[][] worldGrid;

    private void Awake()
    {
        worldGrid = new bool[worldWidth][];

        for (int i = 0; i < worldGrid.Length-1; i++)
        {
            worldGrid[i] = new bool[worldHeight];

            for (int y = 0; y < worldGrid[i].Length; y++)
            {
                worldGrid[i][y] = false;
            }
        }
    }

    private Vector4 GeneratePlanetParam()
    {

        int z = 0;
        int x = 0;
        int size = 0;
        Vector4 result = Vector3.zero;
        do
        {
           
            size = Random.Range(minPlanetSize, maxPlanetSize);

            z = Random.Range(size, worldHeight - size);
            x = Random.Range(size, worldWidth - size);

            result = new Vector4(x, transform.position.y, z, size);
        }
        while (CheckLockPlace(x, z, size));

        BypassGridLock(x, z, size);

        result.x = x - worldWidth / 2;
        result.z = z - worldHeight / 2;

        return result;
    }

    private void BypassGrid(int x, int y, int size, Action<int?,int?> action)
    {
        int deltaX = size ;

        for (int xIndex = x - deltaX; x + deltaX > xIndex; xIndex++)
        {
            for (int yIndex = y - deltaX; y + deltaX > yIndex; yIndex++)
            {
                action(xIndex, yIndex);
            }
        }
    }

    private void  BypassGridLock(int x, int y, int size)
    {
        int deltaX = (size / 2) + 1;

        for (int xIndex = x - deltaX; x + deltaX > xIndex; xIndex++)
        {
            for (int yIndex = y - deltaX; y + deltaX > yIndex; yIndex++)
            {
                worldGrid[(int)xIndex][(int)yIndex] = true;
            }
        }
    }

    private void SetLockPlace(int? xIndex, int? yIndex)
    {     

       worldGrid[(int)xIndex][(int)yIndex] = true;
            
    }

    private bool CheckLockPlace(int x,int y,int size)
    {   
        int deltaX = size / 2;        
        for (int xIndex = x- deltaX; x + deltaX > xIndex; xIndex++)
        {
            for (int yIndex = y - deltaX; y + deltaX > yIndex; yIndex++)
            {               
                if (worldGrid[xIndex][yIndex])
                {
                    return true;
                }               
            }
        }

        return false;
    }

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
            Vector4 spawnPos = GeneratePlanetParam();

            spawnPos.x += transform.position.x;
            spawnPos.z += transform.position.z;


            spawnPos.y = transform.position.y;
            CreatePlanet(spawnPos);
        }

        int playerRandPlanet = Random.Range(0, planetCount);
        ChoosePlayerPlanet(planetControllers[playerRandPlanet]);
    }



    private void CreatePlanet(Vector4 vector3)
    {
        GameObject planetGO = Instantiate(planetPrefab, vector3,Quaternion.identity);
        PlanetController planetController = planetGO.GetComponent<PlanetController>();
        planetControllers.Add(planetController);
        

        planetController.PlanetInfo.SetSize((int)vector3.w);
    }

    private void ChoosePlayerPlanet(PlanetController planetController)
    {
        planetController.ChangeTeam(playerController.PlayerTeam);
    }
}
