using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSpaceship : Spaceship
{
    [SerializeField] private MineralInventory _mineralInventory;

    public MineralInventory MineralInventory { get => _mineralInventory; }
}
