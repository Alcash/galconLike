using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Пулл кораблей
/// </summary>
public class ShipPool : MonoBehaviour
{
    public static ShipPool Instance;

    [SerializeField]
    private ShipController shipPrefab;

    private List<ShipController> objectsPool;

    private List<ShipController> spawnedObjectsPool;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        objectsPool = new List<ShipController>();
        spawnedObjectsPool = new List<ShipController>();
    }

    /// <summary>
    /// взять из пула
    /// </summary>
    /// <returns></returns>
    public ShipController GetObject()
    {

        if(objectsPool.Count == 0)
        {
            AddObject();
        }

        ShipController result = objectsPool.FirstOrDefault();
        objectsPool.Remove(result);
        spawnedObjectsPool.Add(result);
        return result;       
    }

    /// <summary>
    /// Положить в пул
    /// </summary>
    /// <param name="ship"></param>
    public void ReturnToPool(ShipController ship)
    {
        ship.gameObject.SetActive(false);
        objectsPool.Add(ship);
        spawnedObjectsPool.Remove(ship);
    }

    private void AddObject()
    {
        ShipController inst = Instantiate(shipPrefab);
        objectsPool.Add(inst);
    }

    /// <summary>
    /// Спрятать корабли
    /// </summary>
    public void HideShips()
    {

        foreach (var item in spawnedObjectsPool)
        {
            item.gameObject.SetActive(false);

        }
        objectsPool.AddRange(spawnedObjectsPool);
        spawnedObjectsPool.Clear();

    }

}
