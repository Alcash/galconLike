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
    }

    private void AddObject()
    {
        ShipController inst = Instantiate(shipPrefab);
        objectsPool.Add(inst);
    }


}
