using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Вьюха количество кораблей на планете
/// </summary>
public class ShipCountView : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private PlanetInfo planetInfo;

    private Camera camera;

    /// <summary>
    /// Установить планету для отслеживания
    /// </summary>
    /// <param name="planetInfo"></param>
    public void SetPlanetInfo(PlanetInfo info)
    {
        camera = Camera.main;       

        planetInfo = info;
        planetInfo.onInfoChanged.AddListener(UpdateView);

        transform.position = camera.WorldToScreenPoint(planetInfo.transform.position);
        UpdateView();
    }

    private void FixedUpdate()
    {
        if (planetInfo != null)
        {
            transform.position = camera.WorldToScreenPoint(planetInfo.transform.position);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateView()
    {
        text.text = planetInfo.ShipCount.ToString();
    }


    private void OnDestroy()
    {
        planetInfo.onInfoChanged.RemoveListener(UpdateView);
    }

}
