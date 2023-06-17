using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSpaceship : Spaceship
{
    [SerializeField] private MineralInventory _mineralInventory;

    public MineralInventory MineralInventory { get => _mineralInventory; }

    private void Awake()
    {
        _spaceshipType = SpaceshipType.PIRATE;
    }
}
