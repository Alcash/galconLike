using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Вьюха если выбрана планета
/// </summary>
public class SelectedPlanetView : MonoBehaviour
{

    [SerializeField]
    private GameObject selectView;

    private Light lightSelect;

    private float normalRange = 1.5f;

    private PlanetInfo planetInfo;

    protected void Awake()
    {       
        planetInfo = GetComponent<PlanetInfo>();
        planetInfo.onInfoChanged.AddListener(UpdateView);
        lightSelect = selectView.GetComponent<Light>();
    }

    protected void UpdateView()
    {
        if (lightSelect.color != planetInfo.TeamInfo.TeamColor)
        {
            lightSelect.color = planetInfo.TeamInfo.TeamColor;
        }

        if(lightSelect.range != normalRange * transform.localScale.x)
        {
            lightSelect.range = normalRange * transform.localScale.x;
        }
    }

    public void SelectPlanet(bool  balue)
    {
        selectView.SetActive(balue);
    }

    private void OnDestroy()
    {
        planetInfo.onInfoChanged.RemoveListener(UpdateView);
    }
}
