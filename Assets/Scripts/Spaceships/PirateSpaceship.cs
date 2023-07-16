using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSpaceship : Spaceship
{
    [SerializeField] private MineralInventory _mineralInventory;

    public MineralInventory MineralInventory { get => _mineralInventory; }

    protected override void InitSpaceship()
    {
        base.InitSpaceship();
        _spaceshipType = SpaceshipType.PIRATE;
        OccupyingPlanet = GameManager.Instance.PirateManager.GetRandomPiratePlanet();
        transform.position = OccupyingPlanet.transform.position;
        Damagable.OnDeath.AddListener(GameManager.Instance.PirateManager.SpawnPirate);
    }
}
