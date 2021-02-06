using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Вьюха планеты
/// </summary>
[RequireComponent(typeof(PlanetInfo))]
public class PlanetView : TeamView
{
    public static EventPlanet onNewPlanet = new EventPlanet();
    protected override TeamInfo teamInfo { get => planetInfo.TeamInfo; }

    private PlanetInfo planetInfo;

    private float planetSizeOffset = 1;

    protected override void Awake()
    {
        base.Awake();
        planetInfo = GetComponent<PlanetInfo>();
        planetInfo.onInfoChanged.AddListener(UpdateView);
    }

    private void Start()
    {        
        onNewPlanet.Invoke(planetInfo);
    }    

    protected override void UpdateView()
    {
        base.UpdateView();
        float trueSize = planetSizeOffset * planetInfo.Size;

        if (trueSize != transform.localScale.x)
        {
            transform.localScale = Vector3.one * trueSize;
        }
    }

    private void OnDestroy()
    {
        planetInfo.onInfoChanged.RemoveListener(UpdateView);
    }    
}

public class EventPlanet : UnityEvent<PlanetInfo> { }
  
