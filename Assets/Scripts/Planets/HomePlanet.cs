using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanet : Planet
{
    public QuestManager QuestManager;
    [SerializeField] private GameObject _miningShipPrefab;

    private void InstantiateShips(GameObject shipPrefab, int numberOfShips)
    {
        for (int i = 0; i < numberOfShips; i++)
        {
            Instantiate(shipPrefab);
        }
    }

    public void InstantiateMiningShips(int numberOfShips)
    {
        InstantiateShips(_miningShipPrefab, numberOfShips);
    }
}
