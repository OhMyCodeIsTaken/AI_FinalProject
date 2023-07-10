using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSpaceship : Spaceship
{
    [SerializeField] private MineralInventory _mineralInventory;

    public MineralInventory MineralInventory { get => _mineralInventory; }

    protected override void InitSpaceship()
    {
        base.InitSpaceship();
        _spaceshipType = SpaceshipType.MINER;
        OccupyingPlanet = GameManager.Instance.HomePlanet;
        transform.position = GameManager.Instance.HomePlanet.transform.position;
    }
}
