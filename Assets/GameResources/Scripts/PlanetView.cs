using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Вьюха планеты
/// </summary>
[RequireComponent(typeof(PlanetInfo))]
public class PlanetView : TeamView
{
    protected override TeamInfo teamInfo { get => planetInfo.TeamInfo; }

    private PlanetInfo planetInfo;

    protected override void Awake()
    {
        base.Awake();

        planetInfo = GetComponent<PlanetInfo>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        planetInfo.onInfoChanged.AddListener(UpdateView);
    }

    protected override void UpdateView()
    {
        base.UpdateView();
        if (planetInfo.Size != transform.localScale.x)
        {
            transform.localScale = new Vector3(planetInfo.Size, planetInfo.Size, planetInfo.Size);
        }
    }

    private void OnDisable()
    {
        planetInfo.onInfoChanged.RemoveListener(UpdateView);
    }
}
