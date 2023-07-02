using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFactory : MonoBehaviour
{
    [SerializeField] private GameObject _miningShipPrefab;

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
}
