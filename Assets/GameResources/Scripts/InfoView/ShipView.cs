using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Вьюха корабля
/// </summary>
[RequireComponent(typeof(ShipController))]
public class ShipView : TeamView
{
    private ShipController shipController;

    protected override TeamInfo teamInfo { get => shipController.TeamInfo;}

    protected override void Awake()
    {
        base.Awake();

        shipController = GetComponent<ShipController>();
    }
}
