using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Вьюха группы
/// </summary>
public abstract class TeamView : MonoBehaviour
{
    protected abstract TeamInfo teamInfo { get;}

    private MeshRenderer meshRenderer;

    private Material material;


    protected virtual void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        material = meshRenderer.material;
    }

    protected virtual void OnEnable()
    {        
        UpdateView();
       
    }

    protected virtual void UpdateView()
    {
      
        if(teamInfo.MaterialTeam == null)
        {            
            meshRenderer.material.color = teamInfo.TeamColor;
            return;
        }
        if (material.color != teamInfo.MaterialTeam.color)
        {            
            meshRenderer.material = teamInfo.MaterialTeam;
        }        
    }    
}
