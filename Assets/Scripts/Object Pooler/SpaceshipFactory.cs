using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFactory : MonoBehaviour
{
    [SerializeField] private GameObject _miningShipPrefab;
    [SerializeField] private MiningShipPooler _miningShipPooler;
    [SerializeField] private List<MiningSpaceship> _pooledMiningShips;

    private void InstantiateShips(GameObject shipPrefab, int numberOfShips)
    {
        for (int i = 0; i < numberOfShips; i++)
        {
            Instantiate(shipPrefab, transform);
        }
    }

    public void InstantiateMiningShips(int numberOfShips)
    {
        InstantiateShips(_miningShipPrefab, numberOfShips);
    }

    public void GetPooledObjects(int numberOfInstances)
    {
        for (int i = 0; i < numberOfInstances; i++)
        {
            _pooledMiningShips.Add(_miningShipPooler.GetPooledObject());
        }
    }

    public void SetOffPooledObjects(int numberOfInstances)
    {
        for (int i = 0; i < numberOfInstances; i++)
        {
            _miningShipPooler.PushPooledInstance(_pooledMiningShips[0]);
            _pooledMiningShips.RemoveAt(0);
        }
    }
}
