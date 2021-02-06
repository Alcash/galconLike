﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShipViewManager : MonoBehaviour
{
    public static EventPlanet onNewPlanet = new EventPlanet();

    [SerializeField]
    private ShipCountView shipCountViewPrefab;

    private void Awake()
    {
        PlanetView.onNewPlanet.AddListener( NewPlanetHandler);
    }

    private void NewPlanetHandler(PlanetInfo planetInfo)
    {        
        ShipCountView shipCountView = Instantiate(shipCountViewPrefab,transform);
        shipCountView.SetPlanetInfo(planetInfo);
    }

    private void OnDestroy()
    {
        PlanetView.onNewPlanet.AddListener(NewPlanetHandler);
    }
}
